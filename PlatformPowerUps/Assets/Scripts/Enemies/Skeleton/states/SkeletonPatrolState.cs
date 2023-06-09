using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPatrolState : SkeletonState
{
    public SkeletonPatrolState(Skeleton manager, SkeletonStateInstances states)
        : base(manager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        stateManager.audioSource.Play();
        stateManager.animator.Play("Walk");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (playerDetected)
        {
            stateManager.SetNextState(states.Alert);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        stateManager.RB.velocity = direction * stateManager.movementSpeed;

        if (stepHit || wallHit)
        {
            Flip();
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
