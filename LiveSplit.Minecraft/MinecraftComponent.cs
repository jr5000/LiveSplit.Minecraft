// fNbt built from https://github.com/flori-schwa/fNbt since that includes support for TAG_Long_Array

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Minecraft.Properties;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.Minecraft
{
    public class MinecraftComponent : IComponent
    {
        // Limit the rate at which some operations are done since they are too expensive to run on every udpate()
        private const int AUTOSPLITTER_CHECK_DELAY = 500;
        private const int IGT_CHECK_DELAY = 1000;
        private readonly MinecraftSettings settings;
        private readonly TimerModel timer;

        private double lastPositionX;
        private double lastPositionY;
        private double lastPositionZ;
        private long? lastTickCount;

        private string latestSavePath;
        private string latestSaveStatsPath;
        private string latestSaveLogsPath;
        private DateTime nextAutosplitterCheck;
        private DateTime nextIGTCheck;

        private Thread logReadingThread;
        private bool stopped = false;
        
        
        private string[] Splits = new string[0];
        private int CurrentSplit;
        private TimeSpan? LastSplitTime = null;

        public MinecraftComponent(LiveSplitState state)
        {
            settings = new MinecraftSettings(this, state);

            timer = new TimerModel {CurrentState = state};
            state.OnStart += OnStart;
            
            logReadingThread = new Thread(TailLog);
            logReadingThread.IsBackground = true;
            logReadingThread.Start();
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            state.IsGameTimePaused = true;

            if (ShouldCheckIGT()) UpdateIGT();

            if (ShouldCheckAutosplitter())
                if (Settings.Default.AutosplitterEnabled)
                    UpdateAutosplitter();
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        // Unused since the settings are stored as .NET user settings
        public XmlNode GetSettings(XmlDocument document)
        {
            return document.CreateElement("Settings");
        }

        // Unused since the settings are stored as .NET user settings
        public void SetSettings(XmlNode settings)
        {
        }

        public string ComponentName => "Minecraft IGT";

        public IDictionary<string, Action> ContextMenuControls => null;

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
        }

        public float HorizontalWidth => 0;
        public float MinimumWidth => 0;
        public float VerticalHeight => 0;
        public float MinimumHeight => 0;
        public float PaddingBottom => 0;
        public float PaddingLeft => 0;
        public float PaddingRight => 0;
        public float PaddingTop => 0;

        private bool ShouldCheckIGT()
        {
            if (nextIGTCheck != null && DateTime.Now < nextIGTCheck)
                // Not yet
                return false;

            // Haven't attempted yet or it's time to do so
            nextIGTCheck = DateTime.Now.AddMilliseconds(IGT_CHECK_DELAY);
            return true;
        }

        private void UpdateIGT()
        {
            // If the timer is not running yet or if the stats folder doesn't exist (still on world creation) skip
            if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning ||
                !Directory.Exists(latestSaveStatsPath)) return;

            // Update IGT, it uses the stats.json file since level.dat is considered inaccurate
            var igt = TimeSpan.FromSeconds(ExtractTicks() / 20.0);
            if (timer.CurrentState.CurrentPhase == TimerPhase.Running ||
                timer.CurrentState.CurrentPhase == TimerPhase.Paused)
            {
                // Run in process, update time normally
                timer.CurrentState.SetGameTime(igt);
            }
            else if (timer.CurrentState.CurrentPhase == TimerPhase.Ended)
            {
                // Run has ended and IGT has changed, update time with ugly hack
                timer.CurrentState.CurrentSplitIndex--;
                var newSplitTime = new Time
                {
                    RealTime = timer.CurrentState.CurrentSplit.SplitTime.RealTime,
                    GameTime = igt
                };
                timer.CurrentState.CurrentSplit.SplitTime = newSplitTime;
                timer.CurrentState.CurrentSplitIndex++;
                timer.CurrentState.Run.HasChanged = true;
            }
        }

        private bool ShouldCheckAutosplitter()
        {
            if (nextAutosplitterCheck != null && DateTime.Now < nextAutosplitterCheck)
                // Not yet
                return false;

            // Haven't attempted yet or it's time to do so
            nextAutosplitterCheck = DateTime.Now.AddMilliseconds(AUTOSPLITTER_CHECK_DELAY);
            return true;
        }

        private void UpdateAutosplitter()
        {
            latestSavePath = FindLatestSavePath();

            if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning)
            {
                CurrentSplit = 0;
                LastSplitTime = null;
            }
        }

        static string ConstructSearchText(string split)
        {
            if (split.ToLower() == "respawn")
                return
                    "Are you sure you want to respawn? \\n\\n     ??????????????????????????????????????????????????????????????????????????????????????????????????????????????????\\n     >> [Yes] <<\\n";
            if (split.Length > 0 && split[0] == '"' && split[split.Length - 1] == '"')
                return split.Substring(1, split.Length - 2);
            return
                $"Are you sure you want to travel to \\n     {split}?\\n     ??????????????????????????????????????????????????????????????????????????????????????????????????????????????????\\n     >> [Yes] <<\\n";
        }
        
        private void TailLog()
        {
            var stopWatch = Stopwatch.StartNew();
            long lastTime;
            long readAlready = 0;
            bool firstRun = true;
            while (!stopped)
            {
                lastTime = stopWatch.ElapsedMilliseconds;
                string contents;
                if (latestSaveLogsPath != null)
                {
                    using (var fileStream = File.Open(Path.Combine(latestSaveLogsPath, "latest.log"), FileMode.Open,
                        FileAccess.Read, FileShare.ReadWrite))
                    {
                        if (fileStream.Length < readAlready)
                            readAlready = 0;
                        fileStream.Position = readAlready;
                        using (var textReader = new StreamReader(fileStream))
                        {
                            contents = textReader.ReadToEnd();
                        }

                        readAlready += contents.Length;

                        if (!firstRun)
                            MaybeSplit(contents, stopWatch.Elapsed);
                        else
                            firstRun = false;
                    }
                }

                var waitTime = 50 - (stopWatch.ElapsedMilliseconds - lastTime);
                if (waitTime > 0)
                {
                    Thread.Sleep((int)waitTime);
                }
            }
        }

        private void MaybeSplit(string newContent, TimeSpan currentTime)
        {
            while (CurrentSplit < Splits.Length)
            {
                var nextSplitSearch = ConstructSearchText(Splits[CurrentSplit]);
                if (!newContent.Contains(nextSplitSearch)) break;

                if (timer.CurrentState.CurrentPhase == TimerPhase.Running)
                {
                    if (LastSplitTime == null || currentTime - LastSplitTime >= TimeSpan.FromSeconds(5))
                    {
                        CurrentSplit++;
                        timer.Split();
                        LastSplitTime = currentTime;
                    }
                }

                newContent = newContent.Substring(newContent.IndexOf(nextSplitSearch) + nextSplitSearch.Length);
            }
        }

        private string FindLatestSavePath()
        {
            try
            {
                return new DirectoryInfo(Settings.Default.SavesPath)
                    .GetDirectories()
                    .OrderByDescending(x => x.LastWriteTime)
                    .First().FullName;
            }
            catch
            {
                timer.Reset();
                MessageBox.Show("Couldn't find the Minecraft world save.\n\n" +
                                "Check that your saves folder location is correct on the settings page and that there is at least one save on the folder.",
                    ComponentName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private int ExtractTicks()
        {
            var statsFile = Directory.EnumerateFiles(latestSaveStatsPath, "*.json").FirstOrDefault();
            var statsText = File.ReadAllLines(statsFile)[0];
            var statStart = statsText.IndexOf("inute\":") + 7;
            var statEnd = statsText.IndexOf(",", statStart);

            return int.Parse(statsText.Substring(statStart, statEnd - statStart));
        }

        private void OnStart(object sender, EventArgs e)
        {
            var latestSavePath = FindLatestSavePath();
            latestSaveStatsPath = Path.Combine(latestSavePath, "stats");
            if(Settings.Default.SavesPath != null && Settings.Default.SavesPath.Contains("saves"))
                latestSaveLogsPath = Path.Combine(Settings.Default.SavesPath.Substring(0, Settings.Default.SavesPath.IndexOf("saves")), "logs");
            Splits = Settings.Default.Splits.Split(',').Select(name=>name.Trim()).ToArray();
            if (Splits.Length == 0)
            {
                MessageBox.Show("No splits configured.\n\n"+
                                "To add splits, open the settings id edit splits and add the fast travel locations.\n\n"+
                                "The list should be comma-separated.\n\n"+
                                "Make sure the locations are spelled the way they are in game.");
            }
        }

        public void Dispose()
        {
            stopped = true;
        }
    }
}