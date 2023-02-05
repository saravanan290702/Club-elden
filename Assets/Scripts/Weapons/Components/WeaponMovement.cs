using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMovement : WeaponComponent
{
    private Movement coreMovement;
    private Movement CoreMovement => coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);

    private MovementData data;
    private void HandleStartMovement()
    {
        var currentAttackData = data.AttackData[weapon.CurrentAttackCounter];

        CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);
    }

    private void HandleStopMovement()
    {
        CoreMovement.SetVelocityZero();
    }

    protected override void Awake()
    {
        base.Awake();

        data = weapon.Data.GetData<MovementData>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        EventHandler.OnStartMovement += HandleStartMovement;
        EventHandler.OnStopMovement += HandleStopMovement;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        EventHandler.OnStartMovement -= HandleStartMovement;
        EventHandler.OnStopMovement -= HandleStopMovement;
    }
}
