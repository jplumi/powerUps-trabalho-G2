using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPowerUp : PowerUp
{
    public override void PowerUpAction(Collider2D playerCollision)
    {
        PlayerMovement playerMovement = playerCollision.GetComponent<PlayerMovement>();
        playerMovement.maxJumps = 2;
    }
}
