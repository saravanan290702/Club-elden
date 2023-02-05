using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackMovement 
{
    [field:SerializeField] public Vector2 Direction { get; private set; }
    [field:SerializeField] public float Velocity { get; private set; }
}
