using UnityEngine;

namespace Assets.Scripts
{
    public class Ball : MonoBehaviour, ICollidable
    {
        private Rigidbody2D _rigidBody;
        private float _speed;

        public float DbgActualSpeed;
        public Vector2 DbgActualVelocity;

        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                RigidBody.velocity = Velocity.normalized * _speed; 

                UpdateDbgInfo();
            }
        }
        
        public Vector2 Velocity
        {
            get { return RigidBody.velocity; }
            set
            {
                RigidBody.velocity = value;
                _speed = value.magnitude;  

                UpdateDbgInfo();
            }
        }

        public void CollisionExit(Collision2D collision)
        {
            Velocity = Velocity.normalized * Speed;

            UpdateDbgInfo();
        }

        private Rigidbody2D RigidBody
        {
            get { return _rigidBody ?? (_rigidBody = GetComponent<Rigidbody2D>()); }
        }

        private void UpdateDbgInfo()
        {
            DbgActualSpeed = Velocity.magnitude;
            DbgActualVelocity = Velocity;
        }
    }
}
