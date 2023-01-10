using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;

    protected bool isAnimationFinished;
    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    //called wen we enter a state
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
        isAnimationFinished = false;
    }

    //gets called wen we exit a state
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    //gets called every frame
    public virtual void LogicUpdate(){ }

    //gets called every fixed update
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    //its a function which we use to call physics update and from enter
    public virtual void DoChecks() {}

    public virtual void AnimationTrigger() {}

    // to let them know animation is completed
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
