using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("MoveState")]
    public float movementVelocity = 10;

    [Header("Jump State")]
    public float jumpVelocity = 15;
    public int amountOfJumps = 1;

    [Header("IN AIR STATE")]
    public float coyoteTime = 0.2f;
    public float VariableJumpHeightMultiplier = 0.5f; 

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;

}
