using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    private JumpFunction jumpData;

    // DEBUG InputField
    public InputField PlayerHPInputField;
    public InputField JumpPowerInputField;
    public InputField MoveSpeedInputField;
    public InputField AttackDamageInputField;

    public void PlayerHPInputEnd()
    {
        playerData.playerHP = Convert.ToInt32(PlayerHPInputField.text);
    }

    public void JumpPowerInputEnd()
    {
        jumpData.jumpPower = Convert.ToInt32(JumpPowerInputField.text);
    }

    public void MoveSpeedInputEnd()
    {
        playerData.moveSpeed = Convert.ToInt32(MoveSpeedInputField.text);
    }

    public void AttackDamageInputEnd()
    {
        playerData.attackDamage = Convert.ToInt32(AttackDamageInputField.text);
    }
}
