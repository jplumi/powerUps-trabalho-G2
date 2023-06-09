using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1State : AttackState
{
    // constructor
    public PlayerAttack1State(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    //state methods
    public override void EnterState()
    {
        base.EnterState();

        GameManager.instance.canControlPlayer = false;
        stateManager.RB.velocity = Vector2.zero;

        attackDuration = 0.55f;

        stateManager.attackDamageAmount = 30;
        stateManager.animator.Play("AttackSword_1");
        stateManager.audioSource.PlayOneShot(stateManager.atack1_sfx);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (fixedTime >= attackDuration)
        {
            if (shouldCombo)
                stateManager.SetNextState(states.Attack2);
            else
            {
                stateManager.SetNextState(states.Idle);
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
