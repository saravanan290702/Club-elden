using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationEventHandler : MonoBehaviour
{
    public event Action OnFinish;
    public void AnimationFinishedTrigger() => OnFinish?.Invoke();
}
