using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationEventHandler : MonoBehaviour
{
    public event Action OnFinish;
    public event Action OnStartMovement;
    public event Action OnStopMovement;
    private void AnimationFinishedTrigger() => OnFinish?.Invoke();
    private void StartMovementTrigger() => OnStartMovement?.Invoke();
    private void StopMovementTrigger() => OnStopMovement?.Invoke();
}
