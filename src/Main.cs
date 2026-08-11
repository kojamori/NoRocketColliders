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
        public override string ModVersion => "1.0.0";
        public override string Description => "A mod that disables colliders between rockets and other rockets.";
        public override string IconLink => "";

        public override Dictionary<string, string> Dependencies => new Dictionary<string, string>();

        private Harmony _patcher;

        public override void Early_Load()
        {
            _patcher = new Harmony(Instance.ModNameID);
            _patcher.PatchAll();
        }

        private bool rocketCollisionsDisabled = false;

        private void onWorldSceneLoaded() {
            ModKeybindings.AddOnKeyDown_World(new CustomKey() { key = KeyCode.KeypadMultiply }, () =>
            {
                rocketCollisionsDisabled = !rocketCollisionsDisabled;
                ApplyColliderSettings();

                if (rocketCollisionsDisabled) 
                {
                    MsgDrawer.main.Log("Disabled collisions between rockets");
                }
                else 
                {
                    MsgDrawer.main.Log("Enabled collisions between rockets");
                }
            });
        }

        public override void Load()
        {
            // Apply initial collider settings
            ApplyColliderSettings();

            // Add keybind to toggle collider disabling in World
            // Keypad asterisk
            SceneHelper.OnWorldSceneLoaded += onWorldSceneLoaded;
        }

        private void ApplyColliderSettings()
        {
            int parts = LayerMask.NameToLayer("Parts");

            if (rocketCollisionsDisabled)
            {
                Physics2D.IgnoreLayerCollision(parts, parts, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(parts, parts, false);
            }
        }

    }
}
