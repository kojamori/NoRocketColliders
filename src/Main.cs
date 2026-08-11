using System;
using HarmonyLib;
using ModLoader;
using ModLoader.Helpers;
using SFS;
using SFS.Input;
using SFS.Parts;
using SFS.UI;
using System.Collections.Generic;
using UITools;
using UnityEngine;
using static SFS.Input.KeybindingsPC;

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
        public override string ModVersion => "2.0.0";
        public override string Description => "A mod that disables colliders between rockets and other rockets.";
        public override string IconLink => "https://raw.githubusercontent.com/kojamori/NoRocketColliders/refs/heads/main/assets/icon.png";

        public override Dictionary<string, string> Dependencies => new Dictionary<string, string>()
        {
            { "BetterKeybinds", "1.1.0" }
        };

        private Harmony _patcher;

        public override Action LoadKeybindings => NrcKeybindings.LoadKeybindings;

        public override void Early_Load()
        {
            _patcher = new Harmony(Instance.ModNameID);
            _patcher.PatchAll();
        }

        public override void Load()
        {
        }

        

    }
}
