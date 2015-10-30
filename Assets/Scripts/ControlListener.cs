using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ControlListener
    {
        public readonly Dictionary<EAxisOrientation, EventHandler<AxisRawEventArgs>> AxisRowChanged = 
            new Dictionary <EAxisOrientation, EventHandler<AxisRawEventArgs>>
        {
            {EAxisOrientation.Horizontal, null},
            {EAxisOrientation.Vertical, null}
        };
        
        public void CheckControls()
        {
            CheckAxis();
        }

        private void CheckAxis()
        {
            foreach (var axis in AxisRowChanged.Where(x => x.Value != null))
            {
                OnAxisRawChanged(new AxisRawEventArgs
                {
                    AxisRaw = (int) Input.GetAxisRaw(axis.Key.ToString())
                }, 
                axis.Value);
            }
        }
        
        private void OnAxisRawChanged(AxisRawEventArgs e, EventHandler<AxisRawEventArgs> handler)
        {
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class AxisRawEventArgs : EventArgs
    {
        public int AxisRaw { get; set; }
    }
    
    public enum EAxisOrientation
    {
        Unknown = 0,
        Horizontal,
        Vertical
    }
}