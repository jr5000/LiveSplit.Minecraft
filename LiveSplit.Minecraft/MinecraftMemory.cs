using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace LiveSplit.Minecraft
{
    public class MinecraftMemory
    {
        class ScanResult
        {
            public SigScanTarget Scan;
            public IntPtr Pointer;

            public ScanResult(SigScanTarget scan)
            {
                Scan = scan;
                Pointer = IntPtr.Zero;
            }
        }

        public Process MinecraftProcess { get; private set; }
        private readonly MinecraftComponent component;

        public int GetTicks() {
            if (MinecraftProcess != null && ticksPointer != null && MinecraftProcess.ReadValue<int>(ticksPointer, out int ticks))
            {
                return ticks;
            }
            else
            {
                return 0;
            }
        }
        private IntPtr ticksPointer;

        public MinecraftMemory(MinecraftComponent component)
        {
            this.component = component;
        }

        /// <summary>
        /// Attempt to hook the Minecraft process (if not already hooked) and returns wheter it's currently hooked
        /// </summary>
        public bool HookProcess()
        {
            if (MinecraftProcess != null)
            {
                if (MinecraftProcess.HasExited)
                {
                    // The game has exited and we need to clean up
                    MinecraftProcess.Dispose();
                    MinecraftProcess = null;
                    return false;
                }
                // The game was already hooked and has not exited
                return true;
            }

            Process[] processes = Process.GetProcessesByName("javaw");
            if (processes.Length <= 0)
            {
                // Could not find the process
                return false;
            }

            // Found the process
            MinecraftProcess = processes.First();
            return true;
        }

        /// <summary>
        /// Checks the Minecrat version and tries to setup the relevant memory locations. This isn't done on HookProcess() because it's 
        /// not ready if it hooks as Minecraft is launching but it needs to be moved there with an auto delayed retry system
        /// </summary>
        public void SetupAutoSplitterStuff()
        {
            // TODO generalize this and extract version from memory
            var mainWindowTitle = MinecraftProcess.MainWindowTitle;
            var autosplitterSupportedVersions = new[] { "1.16" };
            if (!autosplitterSupportedVersions.Any(x => mainWindowTitle.Contains(x)))
            {
                MessageBox.Show("This Minecraft version is not supported by the autosplitter yet and it has been automatically disabled." +
                    "The version was obtained from the window title.", component.ComponentName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Properties.Settings.Default.AutosplitterEnabled = false;
                Properties.Settings.Default.Save();
                return;
            }

            var scanResults = new List<ScanResult>{
                new ScanResult(new SigScanTarget(0, "7F 6F 5F 4F 3F 2F 1F 0F")),
            };

            foreach (var page in MinecraftProcess.MemoryPages(true))
            {
                var scanner = new SignatureScanner(MinecraftProcess, page.BaseAddress, (int)page.RegionSize);
                foreach (var scanResult in scanResults.Where(x => x.Pointer == IntPtr.Zero))
                {
                    scanResult.Pointer = scanner.Scan(scanResult.Scan);
                }
            }

            if (scanResults.Any(x => x.Pointer == IntPtr.Zero))
            {
                MessageBox.Show("The autosplitter couldn't find a memory region and has been automatically disabled.",
                    component.ComponentName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Properties.Settings.Default.AutosplitterEnabled = false;
                Properties.Settings.Default.Save();
                return;
            }
            ticksPointer = scanResults[0].Pointer + +0x08;
        }
    }
}
