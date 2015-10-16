using UnityEngine;
using System.Collections;

public class Collidable : MonoBehaviour {
    public virtual void onCollisionEnter(Collision2D collision)
    {
    }
    public virtual void onCollisionStay(Collision2D collision)
    {
    }
    public virtual void onCollisionExit(Collision2D collision)
    {
    }
}
