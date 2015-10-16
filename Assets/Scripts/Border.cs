using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.parent.GetComponent<Collidable>().onCollisionEnter(collision);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        this.transform.parent.GetComponent<Collidable>().onCollisionStay(collision);
    }
    protected void OnCollisionExit2D(Collision2D collision)
    {
        this.transform.parent.GetComponent<Collidable>().onCollisionExit(collision);
    }
}
