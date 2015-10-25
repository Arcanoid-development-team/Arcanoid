using UnityEngine;
using System.Collections;

public class Paddle : Collidable
{    
    public float step = 0.3f;
 
    public void Move(int dir)
    {
        if (0 != dir)
        {
            float shift = step * dir;
            transform.position = new Vector3(transform.position.x + shift, transform.position.y);
        }
    }

}
