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
            public const string CONNECT = "CONNECT";
            public const string DISCONNECT = "DISCONNECT";
            public const string FIRST_TICK = "FIRST_TICK";
            public const string CREATE_WORLD = "CREATE_WORLD";
            public const string CREDITS_REACHED = "CREDITS_REACHED";
        }

        private void HandleMinecraftEvent()
        {
            var minecraftEvent = pipeReader.ReadLine();

            // If we are not memory hooked we should probably try to do that asap
            if (component.memory.MinecraftProcess == null && minecraftEvent != MinecraftEvent.DISCONNECT
                && (!component.memory.HookProcess() || !component.memory.FindRelevantMemoryAddress()))
            {
                MessageBox.Show("ERROR CONNECTING TO MC");
            }

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
