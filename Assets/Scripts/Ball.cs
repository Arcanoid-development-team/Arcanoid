using UnityEngine;
using System.Collections;

public class Ball : Collidable {

    public float speed;

    protected Rigidbody2D rb = null;

    // Use this for initialization
    void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    public Vector2 getNormalizedVeclocity(Vector2 velocity, float speed)
    {
        Vector2 resultVelocity = velocity.normalized;
        resultVelocity.Scale(new Vector2(speed, speed));
        return resultVelocity;
    }

    public void adjustVelocity()
    {
        if (this.rb != null)
        {
            this.rb.velocity = this.getNormalizedVeclocity(this.rb.velocity, this.speed);
        }
    }
}
