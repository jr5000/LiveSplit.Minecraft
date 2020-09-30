// fNbt built from https://github.com/flori-schwa/fNbt since that includes support for TAG_Long_Array

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        // Limit the rate at which some operations are done since they are too expensive to run on every udpate()
        private const int AUTOSPLITTER_CHECK_DELAY = 500;
        private const int IGT_CHECK_DELAY = 1000;

        private readonly string[] _113WoolIds =
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

        private readonly bool[] _wools = new bool[16];
        private readonly MinecraftSettings settings;
        private readonly TimerModel timer;

        private string latestSavePath;
        private string latestSaveStatsPath;
        private DateTime nextAutosplitterCheck;
        private DateTime nextIGTCheck;

        public MinecraftComponent(LiveSplitState state)
        {
            settings = new MinecraftSettings(this, state);

            timer = new TimerModel {CurrentState = state};
            state.OnStart += OnStart;
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
            var levelDat = new NbtFile(Path.Combine(latestSavePath, "level.dat"));

            if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning)
                for (var i = 0; i < _wools.Length; i++)
                    _wools[i] = false;

            if (timer.CurrentState.CurrentPhase == TimerPhase.Running &&
                latestSavePath == previousLatestSavePath
                && NewWool(levelDat))
                timer.Split();
        }

        private bool NewWool(NbtFile levelDat)
        {
            var dataFormat = levelDat.RootTag.First()["DataVersion"]?.IntValue ?? -1;
            var playerInventory = levelDat.RootTag.First()["Player"]["Inventory"];
            for (var i = 0; i < 40; i++)
            {
                var slot = playerInventory[i];
                if (slot == null) continue;
                var index = GetWoolIndex(dataFormat, slot);
                if (index == null) continue;
                if (_wools[index.Value]) continue;
                _wools[index.Value] = true;
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
                    for (short i = 0; i < _113WoolIds.Length; i++)
                        if (_113WoolIds[i] == id)
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
    }
}