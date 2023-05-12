using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    public override void PowerUpAction(Collider2D playerCollision)
    {
        PlayerMovement playerMovement = playerCollision.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed *= 2;
    }
}
