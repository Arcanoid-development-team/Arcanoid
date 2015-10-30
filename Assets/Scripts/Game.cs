using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        private readonly ControlListener _controlListener = new ControlListener();

        public Field Field;
        public Player MainPlayer;
        private void Awake () 
        {
            //todo: Нужно добавить возможность выбора доски
            MainPlayer = new Player(Field.Paddles.First());
            
            foreach (Ball ball in Field.Balls)
            {
                ball.Velocity = new Vector2(1.0f,-10.0f); 
                ball.Speed = 5.0f;                
            }

            _controlListener.HorisontalAxisRawChanged += ChangePaddlePosition;
        }
        
        private void Update () 
        {
            _controlListener.CheckControls();
        }

        private void ChangePaddlePosition(object sender, AxisRawEventArgs axisRawEventArgs)
        {
            Field.Paddles.First().Move(axisRawEventArgs.AxisRaw);
        }
    }
}
