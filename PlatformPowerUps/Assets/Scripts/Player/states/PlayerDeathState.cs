using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(PlayerStateManager playerStateManager, PlayerStateInstances states)
        : base(playerStateManager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        GameManager.instance.playerIsInvincible = true;
        GameManager.instance.canControlPlayer = false;

        stateManager.RB.velocity = Vector2.zero;

        stateManager.animator.Play("Death");
        stateManager.audioSource.PlayOneShot(stateManager.death_sfx);
        Object.Destroy(stateManager.gameObject, 2f);

        DisableScripts();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    void DisableScripts()
    {
        stateManager.GetComponent<Damageable>().enabled = false;
        stateManager.GetComponent<PlayerStateManager>().enabled = false;
    }
}
