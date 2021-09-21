using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class PlayButtonUI : MonoSingleton<PlayButtonUI>
{
    public event Action<Vector3> OnMoveButton;
    public event Action<Vector3> OnJumpButton;
    public event Action<PlayerAttackCase> OnAttackButton;

    // Event actions related to movement
    public void RightButton() { OnMoveButton?.Invoke(Vector3.right); }
    public void LeftButton() { OnMoveButton?.Invoke(Vector3.left); }
    public void StopMoveButton() { OnMoveButton?.Invoke(Vector3.zero); }

    // Event actions related to the jump
    public void JumpButton() { OnJumpButton?.Invoke(Vector3.up); }
    public void StopJumpButton() { OnJumpButton?.Invoke(Vector3.zero); }

    // Event actions related to the attack
    public void GeneralAttack() { OnAttackButton?.Invoke(PlayerAttackCase.GENERAL); }
    public void RecallAttack() { OnAttackButton?.Invoke(PlayerAttackCase.RECALL); }
    public void StopAttack() { OnAttackButton?.Invoke(PlayerAttackCase.NOTHING); }

    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnMoveButton?.Invoke(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            OnMoveButton?.Invoke(Vector3.right);
        }
        else
        {
            OnMoveButton?.Invoke(Vector3.zero);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            OnJumpButton?.Invoke(Vector3.up);
        }
        else
        {
            OnJumpButton?.Invoke(Vector3.zero);
        }
    }
}