using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

#pragma warning disable CS0649

enum PlayerState : int
{
    IDLE = 0, MOVE, JUMP, ATTACK, DAMAGE, DIE
}

public class PlayerManager : MonoBehaviour
{
    #region Variables

    [Header("Player HP / MP")]
    public HP playerHP;
    public MP playerMP;

    [Header("Game Inventory(Temp)")]
    public int coin;
    public int[] loot;

    [Header("Special State")]
    public float invinceTime;
    public bool isInvincible = false;

    public bool isWaitUseRelic = false;

    public GameObject relic;

    public bool whileDead = false;

    #endregion

    #region Components

    [HideInInspector]
    public Animator playerAnimator;
    [HideInInspector]
    public SpriteRenderer playerSprite;

    public Animator effectAnimator;
    public Transform effectTransform;

    private PlayerController controller;

    #endregion

    #region Action Functions

    private void Awake()
    {
        loot = new int[4];

        playerAnimator = GetComponentInChildren<Animator>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();

        controller = GetComponent<PlayerController>();

        playerHP.currentHP = playerHP.HP_MAX;
        playerMP.currentMP = playerMP.MP_MAX;
    }

    #endregion

    #region Manage Functions

    // Apply Damage Functions
    public void ApplyDamage(float damage)
    {
        if (whileDead) return;

        controller.isControllable = false;

        playerAnimator.SetTrigger("Damage");
        playerHP.currentHP -= damage;

        effectAnimator.SetTrigger("hit");

        if (playerHP.currentHP <= 0.0f)
        {
            StartCoroutine(Dead());
        }
        else
        {
            if (!isInvincible)
            {
                StartCoroutine(InvinceActivate());
            }
        }

        controller.isControllable = true;
    }

    public void GetCoinTemp(int coinValue)
    {
        coin = coinValue;
    }

    public void GetLootTemp(LootType lootType, int lootValue)
    {
        loot[(int)lootType] = lootValue;
    }

    public bool SpendMana(float manaUsage)
    {
        if (playerMP.currentMP < manaUsage)
        {
            Debug.Log("Not enough mana");
            return false;
        }
        else
        {
            playerMP.currentMP -= manaUsage;
            return true;
        }
    }

    public IEnumerator InvinceActivate()
    {
        isInvincible = true;
        Debug.Log("Invince Activated");
        playerSprite.color = new Color(255.0f, 255.0f, 255.0f, 0.8f);

        yield return new WaitForSeconds(invinceTime);

        isInvincible = false;
        Debug.Log("Invince Deactivated");
        playerSprite.color = new Color(255.0f, 255.0f, 255.0f, 1.0f);

        yield break;
    }

    private IEnumerator Dead()
    {
        whileDead = true;
        // Changed into invincible state, to be unaffected enemy's attack
        isInvincible = true;
        // Change isControllable into false, to stop character
        controller.isControllable = false;

        playerAnimator.SetTrigger("Dead");

        int waitTime = 4;

        StartCoroutine("WaitForUseRelic", waitTime);

        yield return new WaitForSeconds((float)waitTime);

        if (isWaitUseRelic)
            Destroy(gameObject);
        else
        {
            isInvincible = false;
            controller.isControllable = true;
            whileDead = false;
        }
    }

    private IEnumerator WaitForUseRelic(int waitTime)
    {
        isWaitUseRelic = true;

        yield return new WaitForSeconds((float)waitTime);
    }

    #endregion
}