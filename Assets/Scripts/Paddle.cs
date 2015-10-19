using UnityEngine;
using System.Collections;

public class Paddle : Collidable
{    
    public float offset = 0.3f;
 
    protected bool Move(int dir)
    {
        float step = offset * dir;
        transform.position = new Vector3(transform.position.x + step, transform.position.y);
        return true;
    }

    void Update()
    {       
        int dir = (int)(Input.GetAxisRaw("Horizontal"));     

        if (dir != 0)
        {
            Move(dir);
        }
    }
}
