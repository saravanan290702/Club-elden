using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHitBoxData : ComponentData<AttackActionHitBox>
{
    [field: SerializeField] public LayerMask DetectableLayers { get; private set; }
}
