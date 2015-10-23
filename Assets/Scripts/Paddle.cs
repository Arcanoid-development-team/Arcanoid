using UnityEngine;
using System.Collections;

public class Paddle : Collidable
{    
    public float step = 0.3f;
 
    public bool Move(int dir)
    {
        //Debug.Log("MOve puddle");

        if (0 == dir)
    		return true;
    		
        float shift = step * dir;
        transform.position = new Vector3(transform.position.x + shift, transform.position.y);
        return true;
    }

}
