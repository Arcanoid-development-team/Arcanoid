using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Border : MonoBehaviour
    {
        protected void OnCollisionExit2D(Collision2D collision)
        {
            transform.parent.GetComponents<ICollidable>().ToList().ForEach(x => x.CollisionExit(collision));
        }
    }
}
