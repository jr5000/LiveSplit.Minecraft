using fNbt;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.Minecraft
{
    public class MinecraftComponent : UI.Components.IComponent
    {
        private readonly TimerModel timer;
        private readonly MinecraftMemory memoryUtils;
        private readonly MinecraftSettings settings;

        // Limit the rate at which some operations are done since they are too expensive to run on every udpate()
        private DateTime nextHookCheck;
        private DateTime nextSaveFolderCheck;
        private DateTime nextIGTCheck;

        // Unused for now
        private bool autosplitterEnabled;

        private int oldSavesCount = -1;
        private string latestSaveLevelPath;

        public MinecraftComponent(LiveSplitState state)
        {
            memoryUtils = new MinecraftMemory(this);
            settings = new MinecraftSettings(this);

            timer = new TimerModel() { CurrentState = state };
            state.OnStart += OnStart;

            autosplitterEnabled = Properties.Settings.Default.AutosplitterEnabled;

            Properties.Settings.Default.PropertyChanged += OnSettingsChanged;
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            state.IsGameTimePaused = true;

            // If we are not hooked and we shouldn't try yet pass
            if (memoryUtils.MinecraftProcess == null && !ShouldCheckHook()) return;
            // If the hook failed pass
            if (!memoryUtils.HookProcess()) return;

            if (ShouldCheckSaveFolder())
            {
                var savesCount = Directory.EnumerateDirectories(Properties.Settings.Default.SavesPath).Count();

                // If saves count wasn't initialized yet skip this round
                if (oldSavesCount == -1)
                {
                    oldSavesCount = savesCount;
                    return;
                }

                if (savesCount != oldSavesCount)
                {
                    if (savesCount > oldSavesCount)
                    {
                        // The saves count has increased, assume a new world has been created and set the new level.dat path
                        FindLatestSaveLevelPath();
                    }
                    oldSavesCount = savesCount;
                }
            }

            if (ShouldCheckIGT())
            {
                // If the timer is not running yet check if level.dat exists first to avoid exceptions during world creation
                if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning && !File.Exists(latestSaveLevelPath)) return;

                // Update IGT, it uses level.dat since that dates backs to 1.0 and it's faster than reading json stats
                // fNbt built from https://github.com/flori-schwa/fNbt since that includes support for TAG_Long_Array
                var igt = TimeSpan.FromSeconds(new NbtFile(latestSaveLevelPath).RootTag.First()["Time"].LongValue / 20.0);
                if (timer.CurrentState.CurrentPhase == TimerPhase.Running)
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
        }

        private bool ShouldCheckHook()
        {
            if (nextHookCheck != null && DateTime.Now < nextHookCheck)
            {
                // Not yet
                return false;
            }
            else
            {
                // Haven't attempted yet or it's time to do so
                nextHookCheck = DateTime.Now.AddMilliseconds(1000);
                return true;
            }
        }

        private bool ShouldCheckSaveFolder()
        {
            if (nextSaveFolderCheck != null && DateTime.Now < nextSaveFolderCheck)
            {
                // Not yet
                return false;
            }
            else
            {
                // Haven't attempted yet or it's time to do so
                nextSaveFolderCheck = DateTime.Now.AddMilliseconds(250);
                return true;
            }
        }

        private bool ShouldCheckIGT()
        {
            if (nextIGTCheck != null && DateTime.Now < nextIGTCheck)
            {
                // Not yet
                return false;
            }
            else
            {
                // Haven't attempted yet or it's time to do so
                nextIGTCheck = DateTime.Now.AddMilliseconds(250);
                return true;
            }
        }

        private void FindLatestSaveLevelPath()
        {
            try
            {
                var latestSavePath = new DirectoryInfo(Properties.Settings.Default.SavesPath)
                    .GetDirectories()
                    .OrderByDescending(x => x.LastWriteTime)
                    .First().FullName;

                latestSaveLevelPath = Path.Combine(latestSavePath, "level.dat");
            }
            catch
            {
                MessageBox.Show("Couldn't find the Minecraft world save.\n\n" +
                    "Check that your saves location is correct on the settings page and there is already a save to extract the IGT from.",
                    ComponentName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer.Reset();
            }
        }

        private void OnStart(object sender, EventArgs e)
        {
            if (latestSaveLevelPath == null)
            {
                // User manually starts the timer and the component hasn't detected a new save
                FindLatestSaveLevelPath();
            }
        }

        private void OnSettingsChanged(object sender, PropertyChangedEventArgs e)
        {
            // Avoid checking the autosplitter setting on every update()
            var newAutosplitterEnabled = Properties.Settings.Default.AutosplitterEnabled;
            // The change was another setting
            if (autosplitterEnabled == newAutosplitterEnabled) return;

            autosplitterEnabled = newAutosplitterEnabled;
            timer.Reset();
            if (autosplitterEnabled)
            {
                timer.CurrentState.CurrentTimingMethod = TimingMethod.GameTime;
            }
        }

        public void Dispose() { }

        public Control GetSettingsControl(LayoutMode mode) => settings;

        // Unused since the settings are stored as .NET user settings
        public XmlNode GetSettings(XmlDocument document) => document.CreateElement("Settings");
        // Unused since the settings are stored as .NET user settings
        public void SetSettings(XmlNode settings) { }

        public string ComponentName => "Minecraft IGT";

        public IDictionary<string, Action> ContextMenuControls { get; }

        // We take up no space visually, so we return nothing/zero for visual calls from LiveSplit
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) { }
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) { }
        public float HorizontalWidth { get { return 0; } }
        public float MinimumWidth { get { return 0; } }
        public float VerticalHeight { get { return 0; } }
        public float MinimumHeight { get { return 0; } }
        public float PaddingBottom { get { return 0; } }
        public float PaddingLeft { get { return 0; } }
        public float PaddingRight { get { return 0; } }
        public float PaddingTop { get { return 0; } }

    }
}
