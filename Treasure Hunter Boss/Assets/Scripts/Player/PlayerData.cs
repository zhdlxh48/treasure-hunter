﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float moveSpeed = 10;

    //[Range(0.0f, 100.0f)]
    public float playerHP = 100.0f;
    
    public float attackDamage = 10.0f;
    public float generalAttackDelay = 1.0f;
    public float recallAttackDelay = 3.0f;

    public float attackRange = 5.0f;


    //************Temporary function for BossMonster*************//
    public PlayerManager manager;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
    }

    void ApplyDamage(float damage)
    {
        playerHP -= damage;
        
        if (playerHP <= 0)
        {
            manager.SetState(PlayerStateCase.DIE);
        }
    }
}
