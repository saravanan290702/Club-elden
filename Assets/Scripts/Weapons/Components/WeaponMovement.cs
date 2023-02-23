using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMovement : WeaponComponent<MovementData, AttackMovement>
{
    private Movement coreMovement;
    private Movement CoreMovement => coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);

    private void HandleStartMovement()
    {
        CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);
    }

    private void HandleStopMovement()
    {
        CoreMovement.SetVelocityZero();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        eventHandler.OnStartMovement += HandleStartMovement;
        eventHandler.OnStopMovement += HandleStopMovement;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        eventHandler.OnStartMovement -= HandleStartMovement;
        eventHandler.OnStopMovement -= HandleStopMovement;
    }
}
