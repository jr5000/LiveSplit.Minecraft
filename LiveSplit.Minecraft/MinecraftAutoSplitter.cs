using LiveSplit.Minecraft.Properties;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Minecraft
{
    public class MinecraftAutosplitter
    {
        private readonly MinecraftComponent component;

        private readonly PipeSecurity pipeSecurity;

        private HashSet<string> PendingAdvancements;

        public MinecraftAutosplitter(MinecraftComponent component)
        {
            this.component = component;

            pipeSecurity = new PipeSecurity();
            pipeSecurity.SetAccessRule(new PipeAccessRule(
                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                PipeAccessRights.ReadWrite,
                AccessControlType.Allow));
        }

        public void Setup()
        {
            SetupAdvancements();
            SetupPipe();
        }

        private void SetupPipe()
        {
            Task.Run(() =>
            {
                using (var pipe = new NamedPipeServerStream("LiveSplit.Minecraft", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.None, 512, 512, pipeSecurity))
                {
                    pipe.WaitForConnection();
                    using (var reader = new StreamReader(pipe))
                    {
                        while (pipe.IsConnected)
                        {
                            HandleMinecraftEvent(reader);
                        }
                    }
                }
            }).ContinueWith(t => SetupPipe());
        }

        public void SetupAdvancements()
        {
            PendingAdvancements = Settings.Default.Advancements.OfType<string>()
                        .Where(x => x.Split(':')[0] == "True")
                        .Select(x => x.Substring(x.IndexOf(':') + 1))
                        .ToHashSet();
        }

        static class MinecraftEvent
        {
            public const string CONNECT = "CONNECT";
            public const string DISCONNECT = "DISCONNECT";
            public const string START_PLAYING = "START_PLAYING";
            public const string FIRST_INPUT = "FIRST_INPUT";
            public const string CREATE_WORLD = "CREATE_WORLD";
            public const string CREDITS_REACHED = "CREDITS_REACHED";
            public const string ADVANCEMENT_DONE = "ADVANCEMENT_DONE";
        }

        private void HandleMinecraftEvent(StreamReader reader)
        {
            var line = reader.ReadLine();

            // If the read line is not a valid event pass
            if (line == null || !line.StartsWith("EVENT")) return;

            var eventArgs = line.Split(' ');

            // If we are not memory hooked we should probably try to do that asap
            if (component.memory.MinecraftProcess == null && eventArgs[1] != MinecraftEvent.DISCONNECT
                && (!component.memory.HookProcess() || !component.memory.FindRelevantMemoryAddress()))
            {
                MessageBox.Show("ERROR CONNECTING TO MC");
            }

            switch (eventArgs[1])
            {
                case MinecraftEvent.CREATE_WORLD:
                    if (Settings.Default.ResetOnCreation)
                    {
                        component.timer.Reset();
                    }
                    break;
                case MinecraftEvent.START_PLAYING:
                    if (Settings.Default.StartOnJoin)
                    {
                        component.timer.Start();
                    }
                    break;
                case MinecraftEvent.FIRST_INPUT:
                    if (Settings.Default.StartOnFirstInput)
                    {
                        component.timer.Start();
                    }
                    break;
                case MinecraftEvent.CREDITS_REACHED:
                    if (Settings.Default.SplitOnCredits)
                    {
                        if (component.TimingMethod == MinecraftTimingMethod.IGT)
                        {
                            // Make sure to grab the latest igt before splitting
                            component.memory.UpdateIGT();
                        }
                        component.timer.Split();
                    }
                    break;
                case MinecraftEvent.ADVANCEMENT_DONE:
                    if (PendingAdvancements.Contains(eventArgs[2]))
                    {
                        PendingAdvancements.Remove(eventArgs[2]);
                        if (component.TimingMethod == MinecraftTimingMethod.IGT)
                        {
                            // Make sure to grab the latest igt before splitting
                            component.memory.UpdateIGT();
                        }
                        component.timer.Split();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
