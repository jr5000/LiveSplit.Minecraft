using LiveSplit.Minecraft.Properties;
using LiveSplit.Model;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Minecraft
{
    public class MinecraftAutosplitter
    {
        private readonly MinecraftComponent component;

        private NamedPipeServerStream pipe;
        private StreamReader pipeReader;

        public MinecraftAutosplitter(MinecraftComponent component)
        {
            this.component = component;
        }

        public void Setup()
        {
            pipe = new NamedPipeServerStream("LiveSplit.Minecraft", PipeDirection.InOut, -1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            Task.Factory.StartNew(() =>
            {
                pipe.WaitForConnection();
                pipeReader = new StreamReader(pipe);
                while (pipe.IsConnected)
                {
                    HandleMinecraftEvent();
                }
                // TODO figure out a way to reuse the pipe, currently it breaks when MC closes and has to be recreated
                Setup();
            });
        }

        static class MinecraftEvent
        {
            public const string CONNECT = "EVENT CONNECT";
            public const string DISCONNECT = "EVENT DISCONNECT";
            public const string FIRST_TICK = "EVENT FIRST_TICK";
            public const string CREATE_WORLD = "EVENT CREATE_WORLD";
            public const string CREDITS_REACHED = "EVENT CREDITS_REACHED";
            public const string ENTER_NETHER = "EVENT ENTER_NETHER";
        }

        private void HandleMinecraftEvent()
        {
            var minecraftEvent = pipeReader.ReadLine();

            // If we are not memory hooked we should probably try to do that asap
            if (component.memory.MinecraftProcess == null && minecraftEvent != null && minecraftEvent != MinecraftEvent.DISCONNECT
                && (!component.memory.HookProcess() || !component.memory.FindRelevantMemoryAddress()))
            {
                MessageBox.Show("ERROR CONNECTING TO MC");
            }

            // TODO on the connect event it could send the tick count from memory as a temporal value to 
            // write in memory so it doesn't show 0 when resetting mc in runs
            switch (minecraftEvent)
            {
                case MinecraftEvent.CREATE_WORLD:
                    if (Settings.Default.ResetOnCreation)
                    {
                        component.timer.Reset();
                    }
                    break;
                case MinecraftEvent.FIRST_TICK:
                    if (Settings.Default.StartOnJoin)
                    {
                        component.timer.Start();
                    }
                    break;
                case MinecraftEvent.CREDITS_REACHED:
                    if (Settings.Default.SplitOnCredits)
                    {
                        // Make sure to grab the latest igt before splitting
                        component.memory.Update();
                        component.timer.Split();
                    }
                    break;
                case MinecraftEvent.ENTER_NETHER:
                    if (Settings.Default.SplitOnFirstNetherEntrance)
                    {
                        //TODO make this only split THE FIRST TIME
                        // Make sure to grab the latest igt before splitting
                        component.memory.Update();
                        component.timer.Split();
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            pipe?.Dispose();
        }
    }
}
