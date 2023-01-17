using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerAttackState : PlayerAbilitiesState
{
    private Weapon weapon;

    public PlayerAttackState(Player player, 
        PlayerStateMachine stateMachine, 
        PlayerData playerData, 
        string animBoolName, 
        Weapon weapon) 
        : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;
    }

    public override void Enter()
    {
        base.Enter();

        weapon.Enter();
    }
}
