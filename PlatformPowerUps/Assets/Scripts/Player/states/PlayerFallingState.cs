using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    // constructor
    public PlayerFallingState(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    // state methods
    public override void EnterState()
    {
        base.EnterState();

        stateManager.animator.Play("Jump/Fall");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        CheckAttackCombo();
        CheckGunShoot();

        stateManager.animator.SetFloat("verticalMove", stateManager.RB.velocity.y);

        if (stateManager.isGrounded)
        {
            stateManager.audioSource.PlayOneShot(stateManager.landing_sfx);
            stateManager.SetNextState(states.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
