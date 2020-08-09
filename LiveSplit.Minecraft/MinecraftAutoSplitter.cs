using LiveSplit.Minecraft.Properties;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Minecraft
{
    public class MinecraftAutosplitter
    {
        private readonly MinecraftComponent component;

        private NamedPipeServerStream pipe;
        private StreamReader pipeReader;

        private List<string> AdvancementList;

        public MinecraftAutosplitter(MinecraftComponent component)
        {
            this.component = component;
        }

        public void Setup()
        {
            SetupAdvancements();
            pipe = new NamedPipeServerStream("LiveSplit.Minecraft", PipeDirection.InOut, -1, PipeTransmissionMode.Byte, PipeOptions.None);
            Task.Factory.StartNew(() =>
            {
                pipe.WaitForConnection();
                pipeReader = new StreamReader(pipe);
                while (pipe.IsConnected)
                {
                    HandleMinecraftEvent();
                }
                pipe.Disconnect();
                pipe.Dispose();
                // TODO figure out a way to reuse the pipe, currently it breaks when MC closes and has to be recreated
                Setup();
            });
        }

        public void SetupAdvancements()
        {
            AdvancementList = Settings.Default.Advancements.OfType<string>()
                        .Where(x => x.Split(':')[0] == "True")
                        .Select(x => x.Substring(x.IndexOf(':') + 1))
                        .ToList();
        }

        static class MinecraftEvent
        {
            public const string CONNECT = "CONNECT";
            public const string DISCONNECT = "DISCONNECT";
            public const string FIRST_TICK = "FIRST_TICK";
            public const string CREATE_WORLD = "CREATE_WORLD";
            public const string CREDITS_REACHED = "CREDITS_REACHED";
            public const string ADVANCEMENT_DONE = "ADVANCEMENT_DONE";
        }

        private void HandleMinecraftEvent()
        {
            var line = pipeReader.ReadLine();

            // If the read line is not a valid event pass
            if (line == null || !line.StartsWith("EVENT")) return;

            var eventArgs = line.Split(' ');

            // If we are not memory hooked we should probably try to do that asap
            if (component.memory.MinecraftProcess == null && eventArgs[1] != MinecraftEvent.DISCONNECT
                && (!component.memory.HookProcess() || !component.memory.FindRelevantMemoryAddress()))
            {
                MessageBox.Show("ERROR CONNECTING TO MC");
            }

            // TODO on the connect event it could send the tick count from memory as a temporal value to 
            // write in memory so it doesn't show 0 when resetting mc in runs until the world is loaded again
            switch (eventArgs[1])
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
                case MinecraftEvent.ADVANCEMENT_DONE:
                    if (AdvancementList.Contains(eventArgs[2]))
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
