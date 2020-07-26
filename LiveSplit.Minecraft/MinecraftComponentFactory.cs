﻿using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

namespace LiveSplit.Minecraft
{
    //TODO CHECK URLS OF ALL OF THIS STUFF
    class MinecraftComponentFactory : IComponentFactory
    {
        public string ComponentName => "Minecraft IGT";

        public string Description => "Minecraft In-Game Time by Jorkoh https://github.com/Jorkoh/LiveSplit.Minecraft";

        public ComponentCategory Category => ComponentCategory.Timer;

        public string UpdateName => ComponentName;

        public string XMLURL => "https://raw.githubusercontent.com/Jorkoh/LiveSplit.Minecraft/master/" + "Updates.xml";

        public string UpdateURL => "https://raw.githubusercontent.com/Jorkoh/LiveSplit.Minecraft/master/";

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public IComponent Create(LiveSplitState state) => new MinecraftComponent(state);
    }
}