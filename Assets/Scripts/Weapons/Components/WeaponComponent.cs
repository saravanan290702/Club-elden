using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    protected Weapon weapon;

    //protected WeaponAnimationEventHandler EventHandler => weapon.EventHandler;
    protected WeaponAnimationEventHandler eventHandler;
    protected Core Core => weapon.Core;

    protected bool isAttackActive;

    protected virtual void Awake()
    {
        eventHandler = GetComponent<WeaponAnimationEventHandler>();
        weapon = GetComponent<Weapon>();
    }

    protected virtual void HandleEnter()
    {
        isAttackActive = true;
    }

    protected virtual void HandleExit()
    {
        isAttackActive = false;
    }

    protected virtual void OnEnable()
    {
        weapon.OnEnter += HandleEnter;
        weapon.OnExit += HandleExit;
    }

    protected virtual void OnDisable()
    {
        weapon.OnEnter -= HandleEnter;
        weapon.OnExit -= HandleExit;
    }
}
