using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public Field field;
    public float speed = 0;

	// Use this for initialization
	void Awake () {
        Ball ball = field.balls[0];
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(ball.speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        // Debug field, actual speed of the ball
        Ball ball = field.balls[0];
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        speed = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2));
    }
}
