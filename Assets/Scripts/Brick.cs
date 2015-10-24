using UnityEngine;
using System.Collections;

public class Brick : Collidable
{
    // Use this for initialization
    void Awake()
    {
        HitPoints = InitialHitPoints;   // get InitialHitPoints from Unity editor
    }
    
    // Property: hitpoints of a brick
    int HitPoints
    {
        get { return _hitPoints; }
        set 
        {
            _hitPoints = value;
            DbgHitPoints = value;
            if (_hitPoints <= 0)
            {
                Destroy(this.gameObject);       // deletes brick from scene
            }
            // draw different sprite depending on the remaining hitpoints of the brick
            if (_hitPoints == 2)
                this.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/BrickSpriteCracked");
            if (_hitPoints == 1)
                this.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/BrickSpriteRuined");
        }
    }
    private int _hitPoints;         // actual hitpoints
    public int InitialHitPoints;    // for initialization of hitpoints in unity editor
    public int DbgHitPoints;        // dbg display hitpoints speed to Unity editor

    // Is called when brick has stopped touching another rigidbody/collider
    override public void onCollisionExit(Collision2D collision)
    {
        // the only way to get the class of incoming object is to use tags
        if (collision.gameObject.tag == "Ball")
            HitPoints--;
    }
}
