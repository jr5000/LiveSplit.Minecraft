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
        public Process MinecraftProcess { get; private set; }
        private readonly MinecraftComponent component;

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
    }
}
