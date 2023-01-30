using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private int numberOfAttacks;
    [SerializeField] private float attackCounterResetCooldown;

    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set => currentAttackCounter = value >= numberOfAttacks ? 0 : value;
    }

    public event Action OnExit;
    private Animator anim;
    private GameObject baseGameObject;
    private WeaponAnimationEventHandler eventHandler;

    private int currentAttackCounter;

    private Timer attackCounterResetTimer;

    private void Awake()
    {
        baseGameObject = transform.Find("Base").gameObject;
        anim = baseGameObject.GetComponent<Animator>();
        eventHandler = baseGameObject.GetComponent<WeaponAnimationEventHandler>();

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
        anim.SetBool("active", true);
        anim.SetInteger("counter", CurrentAttackCounter);

        attackCounterResetTimer.StopTimer();

        //Debug Statement
        print($"{transform.name} enter");
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
