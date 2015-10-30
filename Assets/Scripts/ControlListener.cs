using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ControlListener
    {
        public event EventHandler<AxisRawEventArgs> HorisontalAxisRawChanged;
        public event EventHandler<AxisRawEventArgs> VerticalAxisRawChanged;
        
        public void CheckControls()
        {
            OnHorisontalAxisRawChanged(new AxisRawEventArgs
            {
                AxisRaw = (int) Input.GetAxisRaw(AxisOrientation.Horizontal.ToString())
            });

            OnVerticalAxisRawChanged(new AxisRawEventArgs
            {
                AxisRaw = (int) Input.GetAxisRaw(AxisOrientation.Vertical.ToString())
            });
        }
        
        private void OnHorisontalAxisRawChanged(AxisRawEventArgs e)
        {
            var hendler = HorisontalAxisRawChanged;
            if (hendler != null)
            {
                hendler(this, e);
            }
        }

        private void OnVerticalAxisRawChanged(AxisRawEventArgs e)
        {
            var hendler = VerticalAxisRawChanged;
            if (hendler != null)
            {
                hendler(this, e);
            }
        }
    }

    public class AxisRawEventArgs : EventArgs
    {
        public int AxisRaw { get; set; }
    }

    public enum AxisOrientation
    {
        Unknown = 0,
        Horizontal,
        Vertical
    }
}