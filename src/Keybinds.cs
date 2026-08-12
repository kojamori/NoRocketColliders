using BetterKeybinds;
using ModLoader;
using ModLoader.Helpers;
using UnityEngine;

namespace NoRocketColliders;

public class NrcKeybindings : ModKeybindings
{
    #region  Singleton

    private static NrcKeybindings instance;

    #endregion

    #region Keybinds

    public CustomKey toggleRocketColliders = KeyCode.KeypadMultiply;

    #endregion

    #region Setup

    public override void CreateUI()
    {
        CreateUI_Text(Main.Instance.DisplayName); 
        CreateUI_Keybinding( toggleRocketColliders, CustomKey.Clone(toggleRocketColliders), "Toggle Rocket Colliders" );
        CreateUI_Space();
    }
    
    public static void LoadKeybindings()
    {
        instance = SetupKeybindings<NrcKeybindings>(Main.Instance);

        SceneHelper.OnWorldSceneLoaded += OnWorldSceneLoad;
    }

    private static void OnWorldSceneLoad()
    {
        AddOnKeyDown_World(instance.toggleRocketColliders, ColliderToggle.OnKeyDown);
    }

    #endregion
    
}