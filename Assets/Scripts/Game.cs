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
            ball.Velocity = new Vector2(-10.0f,0.0f);    // set direction and speed
            ball.Speed = 5.0f;                          // adjust speed
        }
    }
	
    // Update is called once per frame
    void Update () 
    {
        mainPlayer.HandleControl();
    }
}
