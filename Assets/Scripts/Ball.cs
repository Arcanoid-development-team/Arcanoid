using UnityEngine;
using System.Collections;

public class Ball : Collidable
{
    // Property: rigid body of ball with lazy initialization
    private Rigidbody2D RigidBody 
    { 
        get {
            if (_rigidBody == null)
                return _rigidBody = this.GetComponent<Rigidbody2D>();
            else
                return _rigidBody;
        } 
    }
    private Rigidbody2D _rigidBody = null;  // Rigidbody component underneath a Ball object

    // Property: ball speed
    public float Speed          
    {
        get {return _speed;}
        set
        {
            _speed = value;
            RigidBody.velocity = Velocity.normalized * _speed;  // adjust norm of ball velocity vector
            updateDbgInfo();
        }
    }
    private float _speed;       // ball speed

    // Property: ball velocity vector 
    public Vector2 Velocity         
    {
        get { return RigidBody.velocity; }
        set 
        {
            RigidBody.velocity = value;
            _speed = value.magnitude;     // adjust ball speed
            updateDbgInfo();
        }
    }

    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Is called when ball has stopped touching another rigidbody/collider
    override public void onCollisionExit(Collision2D collision)
    {
        Velocity = Velocity.normalized * Speed; // repairs actual length of speed vector after collision
        updateDbgInfo();
    }

    public float DbgActualSpeed;        // actual ball speed (to display in Unity editor)
    public Vector2 DbgActualVelocity;   // actual speed vector of a ball rigidbody (to display in Unity editor)

    // update velocity and speed values displayed in Unity
    private void updateDbgInfo()
    {
        DbgActualSpeed = Velocity.magnitude;    // dbg display actual speed to Unity editor
        DbgActualVelocity = Velocity;           // dbg display actual velocity to Unity editor
    }
}
