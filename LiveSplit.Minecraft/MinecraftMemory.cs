using LiveSplit.ComponentUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace LiveSplit.Minecraft
{
    public class MinecraftMemory
    {
        private readonly MinecraftComponent component;

        public Process MinecraftProcess { get; private set; }

        private int oldTicks = 0;
        private int currentTicks = 0;

        public MinecraftMemory(MinecraftComponent component)
        {
            this.component = component;
        }

        public bool IsStillHooked()
        {
            if (MinecraftProcess == null) return false;

            if (MinecraftProcess.HasExited)
            {
                // The game has exited and we need to clean up
                MinecraftProcess.Dispose();
                MinecraftProcess = null;
                return false;
            }
            else
            {
                // The game is sitll hooked
                return true;

            }
        }

        public bool HookProcess()
        {
            var possibleProcess = Process.GetProcessesByName("javaw").FirstOrDefault();

            if (possibleProcess.HasExited)
            {
                possibleProcess.Dispose();
                return false;
            }
            else
            {
                MinecraftProcess = possibleProcess;
                return true;
            }
        }

        // SCANNING STUFF
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

        public bool FindRelevantMemoryAddress()
        {
            var scanResults = new List<ScanResult>{
                new ScanResult(new SigScanTarget(0, "7F 6F 5F 4F 3F 2F 1F 0F 0F 1F 2F 3F 4F 5F 6F 7F")),
            };

            foreach (var page in MinecraftProcess.MemoryPages(true))
            {
                if ((int)page.RegionSize <= 0) continue;
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
                return false;
            }

            ticksPointer = scanResults[0].Pointer + 0x10;
            return true;
        }

        public void Update()
        {
            oldTicks = currentTicks;
            currentTicks = GetTicks();

            if (oldTicks != currentTicks)
            {
                component.timer.CurrentState.SetGameTime(TimeSpan.FromSeconds(currentTicks / 20.0));
            }
        }


        private int GetTicks()
        {
            if (MinecraftProcess != null && ticksPointer != null && MinecraftProcess.ReadValue(ticksPointer, out int ticks))
            {
                return ticks;
            }
            else
            {
                return 0;
            }
        }
        private IntPtr ticksPointer;
    }
}
