using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControlListener {

        List<ControlEntry> controls;
        public delegate void Handler(int input);

        public ControlListener()
        {
            controls = new List<ControlEntry>();
        }

        public void AddControl(String axisKey, Handler handler)
        {        
            ControlEntry entry = new ControlEntry(axisKey, handler);        
            controls.Add(entry);
        }

        public void CheckControls()
        {
            foreach (ControlEntry control in controls)
            {            
                control.handler((int)(Input.GetAxisRaw(control.axisKey)));
            }
        }

        private class ControlEntry
        {
            private String _axisKey;
            private Handler _handler;

            public ControlEntry(String axisKey, Handler handler)
            {
                this._axisKey = axisKey;
                this._handler = handler;
            }

            public String axisKey
            {
                get {return _axisKey;}
            }
            public Handler handler
            {
                get {return _handler;}
            }
        }
    }
}