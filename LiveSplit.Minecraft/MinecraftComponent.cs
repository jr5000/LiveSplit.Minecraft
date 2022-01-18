// fNbt built from https://github.com/flori-schwa/fNbt since that includes support for TAG_Long_Array

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using fNbt;
using LiveSplit.Minecraft.Properties;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.Minecraft
{
    public class MinecraftComponent : IComponent
    {
        private const int NUM_RETRIES = 50;
        private const int RETRY_MS = 10;
        
        // Limit the rate at which some operations are done since they are too expensive to run on every udpate()
        private const int AUTOSPLITTER_CHECK_DELAY = 500;
        private const int IGT_CHECK_DELAY = 1000;
        private readonly MinecraftSettings settings;
        private readonly TimerModel timer;

        private readonly string[] woolIds113 =
        {
            "white_wool",
            "orange_wool",
            "magenta_wool",
            "light_blue_wool",
            "yellow_wool",
            "lime_wool",
            "pink_wool",
            "gray_wool",
            "light_gray_wool",
            "cyan_wool",
            "purple_wool",
            "blue_wool",
            "brown_wool",
            "green_wool",
            "red_wool",
            "black_wool"
        };

        private readonly bool[] wools = new bool[16];

        private string latestSavePath;
        private string latestSaveStatsPath;
        private DateTime nextAutosplitterCheck;
        private DateTime nextIGTCheck;
        private FileSystemWatcher watcher;

        public MinecraftComponent(LiveSplitState state)
        {
            settings = new MinecraftSettings(this, state);

            timer = new TimerModel {CurrentState = state};
            state.OnStart += OnStart;
            state.OnReset += OnReset;
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            state.IsGameTimePaused = true;

            if (ShouldCheckIGT()) UpdateIGT();

            if (Settings.Default.AutosplitterEnabled && ShouldCheckAutosplitter()) UpdateAutosplitter();
        }

        public void Dispose()
        {
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

        public IDictionary<string, Action> ContextMenuControls { get; }

        // We take up no space visually, so we return nothing/zero for visual calls from LiveSplit
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
            var previousLatestSavePath = latestSavePath;
            latestSavePath = FindLatestSavePath();
            if (latestSavePath != previousLatestSavePath)
            {
                if (timer.CurrentState.CurrentPhase == TimerPhase.Running)
                {
                    ResetWools();
                    timer.Reset(true);
                }
                watcher?.Dispose();
                watcher = new FileSystemWatcher
                {
                    Path = latestSavePath, NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                                                                   | NotifyFilters.FileName |
                                                                                   NotifyFilters.DirectoryName |
                                                                                   NotifyFilters.Size |
                                                                                   NotifyFilters.Attributes,
                    Filter = "*.*"
                };
                watcher.Renamed += NewLevelDat;
                watcher.Created += SessionLock;
                watcher.Changed += SessionLock;
                watcher.EnableRaisingEvents = true;

                CheckExistingSessionLock();

            }

            if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning)
                ResetWools();
        }

        private void ResetWools()
        {
            for (var i = 0; i < wools.Length; i++)
                wools[i] = false;
        }

        private void CheckExistingSessionLock()
        {
            var fullPath = Path.Combine(latestSavePath, "session.lock");
            if (File.Exists(fullPath)) MaybeStart(fullPath);
        }

        private long? ReadTimestampFromSessionLock(string fullPath)
        {
            var startingLatestSavePath = latestSavePath;
            // It's possible that we're so fast that either Minecraft hasn't finished writing the file
            // or hasn't yet released the filesystem lock, so do the dumb hacky thing of retry for a few milliseconds lol
            for (var i = 0; i < NUM_RETRIES && latestSavePath == startingLatestSavePath; i++)
                try
                {
                    using (var reader = new BinaryReader(new FileStream(fullPath, FileMode.Open)))
                    {
                        var bytes = reader.ReadBytes(8);
                        if (BitConverter.IsLittleEndian)
                        {
                            Array.Reverse(bytes);
                        }

                        return BitConverter.ToInt64(bytes, 0);
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(RETRY_MS);
                }

            MessageBox.Show("Could not read session.lock");
            return null;
        }

        private void MaybeStart(string fullPath)
        {
            var timestamp = ReadTimestampFromSessionLock(fullPath);
            if (!timestamp.HasValue)
                return;

            var curr = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var diffInMs = curr - timestamp.Value;
            //MessageBox.Show($"diffInMs: {diffInMs}, timestamp: {timestamp}, curr: {curr}");
            if (diffInMs > 1000 * 10)
                return;
            timer.CurrentState.Run.Offset = TimeSpan.FromMilliseconds(diffInMs);
            timer.Start();
            //MessageBox.Show($"diffInMs: {diffInMs}\n\ncurrentTime: {timer.CurrentState.CurrentTime.RealTime.Value.TotalMilliseconds}");
            
            if (File.Exists(Path.Combine(latestSavePath, "level.dat")))
            {
                var startingLatestSavePath = latestSavePath;
                int i;
                for (i = 0; i < NUM_RETRIES && latestSavePath == startingLatestSavePath; i++)
                    try
                    {
                        var levelDat = new NbtFile(Path.Combine(latestSavePath, "level.dat"));
                        while (NewWool(levelDat)) ;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(RETRY_MS);
                    }

                if (i == 5)
                {
                    MessageBox.Show("Couldn't read level.dat");
                }
            }
        }

        private void SessionLock(object sender, FileSystemEventArgs e)
        {
            if (timer.CurrentState.CurrentPhase == TimerPhase.Running) return;
            if (e.Name == "session.lock") MaybeStart(e.FullPath);
        }

        private void NewLevelDat(object sender, RenamedEventArgs e)
        {
            if (e.Name == "session.lock") MaybeStart(e.FullPath);
            if (e.Name != "level.dat" || e.OldName != "level.dat_new" ||
                e.ChangeType != WatcherChangeTypes.Renamed) return;
            if (timer.CurrentState.CurrentPhase != TimerPhase.Running) return;

            // It's possible that we're so fast that either Minecraft hasn't finished writing the file
            // or hasn't yet released the filesystem lock, so do the dumb hacky thing of retry for a few milliseconds lol
            for (var i = 0; i < NUM_RETRIES; i++)
                try
                {
                    var nbtFile = new NbtFile(e.FullPath);
                    while (NewWool(nbtFile))
                        timer.Split();
                    return;
                }
                catch (Exception)
                {
                    Thread.Sleep(RETRY_MS);
                }
        }

        private bool NewWool(NbtFile levelDat)
        {
            var dataFormat = levelDat.RootTag.First()["DataVersion"]?.IntValue ?? -1;
            if (!(levelDat.RootTag.First()["Player"]["Inventory"] is NbtList playerInventory)) return false;
            for (var i = 0; i < playerInventory.Count; i++)
            {
                var slot = playerInventory[i];
                var index = GetWoolIndex(dataFormat, slot);
                if (index == null) continue;
                if (wools[index.Value]) continue;
                wools[index.Value] = true;
                return true;
            }

            return false;
        }

        private short? GetWoolIndex(int dataFormat, NbtTag slot)
        {
            if (slot["id"].TagType == NbtTagType.String)
            {
                var id = slot["id"].StringValue;
                if (dataFormat >= 1451)
                {
                    for (short i = 0; i < woolIds113.Length; i++)
                        if (woolIds113[i] == id)
                            return i;

                    return null;
                }

                if (id != "minecraft:wool") return null;
                var damage = slot["Damage"].ShortValue;
                return damage;
            }
            else
            {
                var id = slot["id"].ShortValue;
                if (id != 35) return null;
                var damage = slot["Damage"].ShortValue;
                return damage;
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
            latestSaveStatsPath = Path.Combine(FindLatestSavePath(), "stats");
        }

        private void OnReset(object sender, TimerPhase timerPhase)
        {
            timer.CurrentState.Run.Offset = TimeSpan.Zero;
        }
    }
}