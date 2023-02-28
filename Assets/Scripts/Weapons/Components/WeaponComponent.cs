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

    protected virtual void Start()
    {

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

public abstract class WeaponComponent<T1,T2> : WeaponComponent where T1 : ComponentData<T2> where T2 : AttackData
{
    protected T1 data;
    protected T2 currentAttackData;

    protected override void HandleEnter()
    {
        base.HandleEnter();

        currentAttackData = data.AttackData[weapon.CurrentAttackCounter];
    }

    protected override void Awake()
    {
        base.Awake();

        data = weapon.Data.GetData<T1>();
    }
}
