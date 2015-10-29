using UnityEngine;

namespace Assets.Scripts
{
    public class Ball : MonoBehaviour, ICollidable
    {
        private Rigidbody2D _rigidBody;
        private float _speed;
        private readonly GameObjectDebugger _objectDebugger;
        
        public Ball()
        {
            _objectDebugger = new GameObjectDebugger(this);
        }

        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                RigidBody.velocity = Velocity.normalized * _speed;
            }
        }
        
        public Vector2 Velocity
        {
            get { return RigidBody.velocity; }
            set
            {
                RigidBody.velocity = value;
                _speed = value.magnitude;
            }
        }

        public void CollisionExit(Collision2D collision)
        {
            Velocity = Velocity.normalized * Speed;

            _objectDebugger.UpdateDebugInfo("Столкновение закончено");
        }

        private Rigidbody2D RigidBody
        {
            get { return _rigidBody ?? (_rigidBody = GetComponent<Rigidbody2D>()); }
        }
    }
}
