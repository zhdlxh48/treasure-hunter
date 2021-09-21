using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649

public class HealthManager : MonoBehaviour
{
    #region Components
    
    private PlayerManager manager;

    [Header("Bar Units")]
    public HPBar HPBar;
    public MPBar MPBar;

    private float HP_MAX;
    private float MP_MAX;

    #endregion

    #region Events Functions

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        HP_MAX = manager.playerHP.HP_MAX;
        MP_MAX = manager.playerMP.MP_MAX;
    }

    private void Update()
    {
        SetBars();
    }

    private void SetBars()
    {
        HPBar.SetBar(HP_MAX, manager.playerHP.currentHP);
        MPBar.SetBar(MP_MAX, manager.playerMP.currentMP);
    }

    #endregion
}
