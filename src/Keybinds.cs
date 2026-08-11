using BetterKeybinds;
using ModLoader;
using UnityEngine;

namespace NoRocketColliders;

public class Keybindings : ModKeybindings
{
    public CustomKey MyAction = KeyCode.KeypadMultiply;

    public override void CreateUI()
    {
        CreateUI_Text(BetterKeybinds.Main.Instance.DisplayName); 
        CreateUI_Keybinding( MyAction, KeyCode.F5, "Toggle Rocket Colliders" );
    }
    
    private static Keybindings keybindings;

    public static void LoadKeybindings()
    {
        keybindings = SetupKeybindings<Keybindings>(Main.Instance); 
    }
}