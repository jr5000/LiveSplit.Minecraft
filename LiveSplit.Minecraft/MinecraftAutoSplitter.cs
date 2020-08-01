using LiveSplit.Model;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
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
                    switch (pipeReader.ReadLine())
                    {
                        case "EVENT: CONNECT":
                            if (!component.memory.HookProcess() || !component.memory.FindRelevantMemoryAddress())
                            {
                                MessageBox.Show("ERROR CONNECTING TO MC");
                            }
                            break;
                        case "EVENT: DISCONNECT":
                            break;
                        case "EVENT: CREATE_WORLD":
                            component.timer.Reset();
                            break;
                        case "EVENT: FIRST_TICK":
                            component.timer.Start();
                            break;
                        case "EVENT: CREDITS_REACHED":
                            // Make sure to grab the latest igt before splitting
                            component.memory.Update();
                            component.timer.Split();
                            break;
                        default:
                            break;
                    }
                }
                // TODO figure out a way to reuse the pipe, currently it breaks when MC closes and has to be recreated
                Setup();
            });
        }

        public void Dispose()
        {
            pipe?.Dispose();
        }
    }
}
