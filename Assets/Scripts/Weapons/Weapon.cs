using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [field: SerializeField] public WeaponDataSO Data { get; private set; }
    [SerializeField] private float attackCounterResetCooldown;

    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set => currentAttackCounter = value >= Data.NumberOfAttacks ? 0 : value;
    }
    
    public event Action OnEnter;
    public event Action OnExit;

    private Animator anim;
    public GameObject BaseGameObject { get; private set; }
    public GameObject WeaponSpriteObject { get; private set; }

    private WeaponAnimationEventHandler eventHandler;

    private int currentAttackCounter;

    private Timer attackCounterResetTimer;

    private void Awake()
    {
        BaseGameObject = transform.Find("Base").gameObject;

        WeaponSpriteObject = transform.Find("WeaponSprite").gameObject;

        anim = BaseGameObject.GetComponent<Animator>();

        eventHandler = BaseGameObject.GetComponent<WeaponAnimationEventHandler>();

        attackCounterResetTimer = new Timer(attackCounterResetCooldown);
    }

    private void Update()
    {
        attackCounterResetTimer.Tick();
    }

    private void ResetAttackCounter() => CurrentAttackCounter = 0;

    private void Exit()
    {
        anim.SetBool("active", false);

        CurrentAttackCounter++;
        attackCounterResetTimer.StartTimer();

        OnExit?.Invoke();
    }
    public void Enter()
    {


        attackCounterResetTimer.StopTimer();
            
        anim.SetBool("active", true);
        anim.SetInteger("counter", CurrentAttackCounter);

        //Debug Statement
        print($"{transform.name} enter");

        OnEnter?.Invoke();
    }

    private void OnEnable()
    {
        eventHandler.OnFinish += Exit;
        attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
    }

    private void OnDisable()
    {
        eventHandler.OnFinish -= Exit;
        attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
    }
}
