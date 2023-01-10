using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerinAirState : PlayerState
{
    private int xinput;
    private bool isGrounded;
    private bool jumpInput;
    private bool JumpInputStop;
    private bool coyoteTime;
    public bool isJumping;
  
    public PlayerinAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();

        xinput = player.InputHandler.NormalizedX;
        jumpInput = player.InputHandler.JumpInput;
        JumpInputStop = player.InputHandler.JumpInputStop;

        CheckMultiplier();

        if(isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if(jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else
        {
            player.CheckShouldFlip(xinput);
            player.SetVelocityX(playerData.movementVelocity * xinput);

            player.Anim.SetFloat("yVelocity",player.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));

        }
    }

    private void CheckMultiplier()
    {

        if (isJumping)
        {
            if (JumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.VariableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if(coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartCoyoteTime() => coyoteTime=true;
    public void SetIsJumping() => isJumping = true;
}
