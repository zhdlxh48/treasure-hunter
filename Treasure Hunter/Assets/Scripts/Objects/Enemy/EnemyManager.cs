using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyState
{
    STOP, MOVE, ATTACK, DAMAGE, DIE
}

public enum EnemyType
{
    SLIME, FLOWER
}

[System.Serializable]
public struct EnemyAttackSetting
{
    public float minAttackDamage;
    public float maxAttackDamage;
    public Vector2 attackRange;
    public float attackDelay;
    public bool isAttackable;
}

public class EnemyManager : MonoBehaviour
{
    #region Variables

    public EnemyType enemyType;

    public Dictionary<EnemyState, EnemyFSMState> enemyStates;
    public EnemyState generalState;

    public HP enemyHP;

    public GameObject dropItem;

    public Transform effectTransform;
    public Animator effectAnimator;
    public SpriteRenderer effectSprite;

    public Vector3 moveDirection;
    public float moveSpeed;
    public bool isMovable;

    public EnemyAttackSetting enemyAttack;
    public PlayerManager attackTarget;

    #endregion

    #region Components

    [HideInInspector]
    public BoxCollider2D enemyCollider;
    private BoxCollider2D playerCollider;

    [HideInInspector]
    public Animator enemyAnimator;
    [HideInInspector]
    public SpriteRenderer enemySprite;

    #endregion

    #region Event Functions

    private void Awake()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        playerCollider = FindObjectOfType<PlayerManager>().gameObject.GetComponent<BoxCollider2D>();

        enemyAnimator = GetComponentInChildren<Animator>();
        enemySprite = GetComponentInChildren<SpriteRenderer>();

        enemyStates = new Dictionary<EnemyState, EnemyFSMState>();

        enemyHP.currentHP = enemyHP.HP_MAX;

        moveDirection = Vector3.right;

        enemyAttack.isAttackable = true;

        isMovable = false;

        InitStates();
    }

    private void Start()
    {
        Physics2D.IgnoreCollision(enemyCollider, playerCollider, true);

        SetState(generalState);
    }

    // if Enemy is trigger with Enemy_Wall, change Direction
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy_Wall"))
        {
            DirectionChange();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Frame") || other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isMovable = true;
        }
    }

    #endregion

    #region Action Functions

    public void InitStates()
    {
        EnemyStateInitOffset(ref enemyStates, enemyType);

        foreach (var item in enemyStates)
        {
            item.Value.enabled = false;
        }
    }

    public void SetState(EnemyState tempState)
    {
        foreach (var item in enemyStates)
        {
            item.Value.enabled = false;
        }

        enemyStates[tempState].enabled = true;
    }

    public void EnemyStateInitOffset(ref Dictionary<EnemyState, EnemyFSMState> enemyStates, EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.SLIME:
                enemyStates[EnemyState.MOVE] = GetComponent<EnemyMOVE>();
                enemyStates[EnemyState.ATTACK] = GetComponent<EnemyATTACK>();
                enemyStates[EnemyState.DAMAGE] = GetComponent<EnemyDAMAGE>();
                enemyStates[EnemyState.DIE] = GetComponent<EnemyDEAD>();
                break;

            case EnemyType.FLOWER:
                enemyStates[EnemyState.STOP] = GetComponent<EnemySTOP>();
                enemyStates[EnemyState.ATTACK] = GetComponent<EnemyATTACK>();
                enemyStates[EnemyState.DAMAGE] = GetComponent<EnemyDAMAGE>();
                enemyStates[EnemyState.DIE] = GetComponent<EnemyDEAD>();
                break;
        }
    }

    public void DirectionChange()
    {
        //transform.rotation = (transform.rotation.y == 0.0f ? Quaternion.Euler(0.0f, 180.0f, 0.0f) : Quaternion.Euler(0.0f, 0.0f, 0.0f));
        if (moveDirection != Vector3.right)
        {
            moveDirection = Vector3.right;
            enemySprite.flipX = false;

            effectSprite.flipX = false;
        }
        else
        {
            moveDirection = Vector3.left;
            enemySprite.flipX = true;

            effectSprite.flipX = true;
        }
    }

    public IEnumerator AttackDelay()
    {
        enemyAttack.isAttackable = false;

        yield return new WaitForSeconds(enemyAttack.attackDelay);

        enemyAttack.isAttackable = true;

        yield break;
    }

    public void ApplyDamage(float damage)
    {
        enemyHP.currentHP -= damage;

        effectAnimator.SetTrigger("hit");

        SetState(EnemyState.DAMAGE);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    #endregion
}
