using System;
using ModLoader;
using System.Collections.Generic;

namespace NoRocketColliders
{
    public class Main : Mod
    {
        public static Main Instance { get; private set; }
        public Main()
        {
            Instance = this;
        }

        public override string ModNameID => "NoRocketColliders";
        public override string DisplayName => "NoRocketColliders";
        public override string Author => "kojamori";
        public override string MinimumGameVersionNecessary => "1.6.00.16";
        public override string ModVersion => "2.1.0";
        public override string Description => "A mod that disables colliders between rockets and other rockets.";
        public override string IconLink => "https://raw.githubusercontent.com/kojamori/NoRocketColliders/refs/heads/main/assets/icon.png";

        public override Dictionary<string, string> Dependencies => new Dictionary<string, string>()
        {
            { "BetterKeybinds", "2.0.0" }
        };

        public override Action LoadKeybindings => NrcKeybindings.LoadKeybindings;

        public override void Early_Load()
        {
        }

        public override void Load()
        {
        }

        

    }
}
