using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControlListener
    {
        public readonly Dictionary<EAxisName, EventHandler<AxisRawEventArgs>> AxisRowChanged = 
            new Dictionary <EAxisName, EventHandler<AxisRawEventArgs>>
        {
            {EAxisName.Horizontal, null},
            {EAxisName.Vertical, null},
            {EAxisName.FireBall, null}
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
                handler(null, e);
            }
        }
    }

    public class AxisRawEventArgs : EventArgs
    {
        public int AxisRaw { get; set; }
    }
    
    public enum EAxisName
    {
        Unknown = 0,
        Horizontal,
        Vertical,
        FireBall
    }
}