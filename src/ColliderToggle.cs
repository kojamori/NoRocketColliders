using SFS.UI;
using UnityEngine;

namespace NoRocketColliders;

public static class ColliderToggle
{
    private static bool rocketCollisionsDisabled = false;
    public static void ApplyColliderSettings()
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

    public static void OnKeyDown()
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
    }
}