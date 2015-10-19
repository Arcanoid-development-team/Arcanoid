using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public Field field;

    // Use this for initialization
    void Awake () 
    {
        // set up the same inital speed vector for all balls
        foreach (Ball ball in field.balls)
        {
            ball.Velocity = new Vector2(-10.0f,0.0f);    // set direction and speed
            ball.Speed = 5.0f;                          // adjust speed
        }
    }
	
    // Update is called once per frame
    void Update () 
    {
    }
}
