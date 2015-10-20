using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public Field field;
    public Player mainPlayer = null;

    // Use this for initialization
    void Awake () 
    {
        mainPlayer = new Player(field.paddles[0]); /* Нужно добавить возможность выбора доски */

        // set up a same inital speed vector for all balls
        foreach (Ball ball in field.balls)
        {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();  // get rigidbody of ball
            rb.velocity = new Vector2(ball.speed, 0);           // now ball will be launched straight to the right
        }
    }
	
    // Update is called once per frame
    void Update () 
    {
        mainPlayer.HandleControl();

        // Debug field, actual speed of all balls
        foreach (Ball ball in field.balls)
        {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();                                      // get rigidbody of a ball
            float speed = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2));    // actual ball speed
        }
    }
}
