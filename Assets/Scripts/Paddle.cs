using UnityEngine;

namespace Assets.Scripts
{
    public class Paddle : MonoBehaviour
    {    
        public float Step = 0.3f;
        public void Move(int dir)
        {
            if (dir != 0)
            {
                var shift = Step * dir;
                transform.position = new Vector3(transform.position.x + shift, transform.position.y);
            }
        }
    }
}
