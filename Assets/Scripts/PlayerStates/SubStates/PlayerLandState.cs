using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    protected bool isGrounded;
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xinput != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }
        else if(isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (player.CurrentVelocity.x != 0 && isGrounded) // If they landing moving, don't freeze them in a landing animation
        {
            player.StateMachine.ChangeState(player.MoveState);
        }
        else // Else if they land without moving, go to Idle State
        {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }
}
