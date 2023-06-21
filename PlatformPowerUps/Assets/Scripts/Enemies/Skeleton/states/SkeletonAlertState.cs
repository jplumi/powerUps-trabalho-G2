using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAlertState : SkeletonState
{
    Transform player;

    bool attackRange = false;

    public SkeletonAlertState(Skeleton manager, SkeletonStateInstances states)
         : base(manager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        stateManager.animator.Play("Walk");

        stateManager.movementSpeed *= 1.5f;

        player = GameObject.Find("Player").transform;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (attackRange)
        {
            stateManager.SetNextState(states.Attack);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();


        GetPlayerDirection();
        CheckDirection();
        CheckAttackRange();
        stateManager.RB.velocity = direction * stateManager.movementSpeed;
    }

    public override void ExitState()
    {
        base.ExitState();
        stateManager.movementSpeed /= 1.5f;
        attackRange = false;
    }

    void GetPlayerDirection()
    {
        float enemyXPosition = stateManager.gameObject.transform.position.x;
        if(player.position.x < enemyXPosition)
            direction = Vector2.left;
        else
            direction = Vector2.right;
    }

    void CheckDirection()
    {
        if(stateManager.RB.velocity.x < 0)
            stateManager.transform.eulerAngles = new Vector2(0, 180);
        else
            stateManager.transform.eulerAngles = new Vector2(0, 0);
    }

    void CheckAttackRange()
    {
        Vector2 origin = stateManager.gameObject.transform.position + new Vector3(0, 0.5f);
        float raycastDistance = 2.5f;
        attackRange = Physics2D.Raycast(
            origin,
            direction,
            raycastDistance,
            stateManager.playerLayer);

        Debug.DrawRay(origin, direction * raycastDistance, Color.yellow);
    }
}