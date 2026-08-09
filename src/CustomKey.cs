using SFS.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoRocketColliders
{
    public class CustomKey : I_Key
    {

        bool I_Key.IsKeyDown()
        {
            UnityEngine.Debug.Log(Input.GetKeyDown(this.key));
            return Input.GetKeyDown(this.key) && this.HoldingControl && this.HoldingShift && this.HoldingAlt;

        }

        bool I_Key.IsKeyStay()
        {
            return Input.GetKey(this.key);
        }

        bool I_Key.IsKeyUp()
        {
            return Input.GetKeyUp(this.key);
        }

        private bool HoldingControl
        {
            get
            {
                return this.ctrl == Input.GetKey(KeyCode.LeftControl);
            }
        }

        private bool HoldingShift
        {
            get
            {
                return this.shift == Input.GetKey(KeyCode.LeftShift);
            }
        }

        private bool HoldingAlt
        {
            get
            {
                return this.alt == Input.GetKey(KeyCode.LeftAlt);
            }
        }

        public bool ctrl;
        public bool shift;
        public bool alt;
        public KeyCode key;
    }
}
