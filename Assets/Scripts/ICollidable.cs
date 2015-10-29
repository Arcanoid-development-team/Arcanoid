using UnityEngine;

namespace Assets.Scripts
{
    public interface ICollidable
    {
        void CollisionExit(Collision2D collision);
    }
}
