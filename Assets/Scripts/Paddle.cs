using UnityEngine;
using System.Collections;

public class Paddle : Collidable
{    
    public float offset = 0.3f;
 
    public bool Move(int dir)
    {
        float step = offset * dir;
        transform.position = new Vector3(transform.position.x + step, transform.position.y);
        return true;
    }

}
