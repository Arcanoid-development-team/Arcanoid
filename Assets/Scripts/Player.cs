using UnityEngine;
using System.Collections;

public class Player
{
    private Paddle playerPaddle = null;

    public Player(Paddle paddle)
    {
        playerPaddle = paddle;
    }


    public void HandleControl()
    {
        int dir = (int)(Input.GetAxisRaw("Horizontal"));

        if (dir != 0)
        {
            playerPaddle.Move(dir);
        }
    }
	
}
