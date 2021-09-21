using System;
using UnityEngine;
using System.Collections;

public class EnemyMOVE : EnemyFSMState
{
    private void Awake()
    {
        manager.attackTarget = null;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        StateChange();
    }

    private void Move()
    {
        if (manager.isMovable)
        {
            transform.Translate(manager.moveDirection * manager.moveSpeed * Time.deltaTime);
        }
    }

    private void StateChange()
    {
        Collider2D[] playerDetect = Physics2D.OverlapBoxAll(transform.position + (Vector3)manager.enemyCollider.offset, manager.enemyAttack.attackRange, 0.0f);

        foreach (var item in playerDetect)
        {
            if (item.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                manager.attackTarget = item.transform.root.GetComponent<PlayerManager>();

                //if (PlayerController.faceDirection != manager.moveDirection)
                //{
                //    if (!manager.attackTarget.isInvincible && manager.enemyAttack.isAttackable)
                //    {
                //        manager.SetState(EnemyState.ATTACK);
                //    }
                //}

                if (PlayerController.faceDirection == Vector3.right)
                {
                    if (manager.moveDirection == Vector3.right 
                        && (FindObjectOfType<PlayerController>().playerTransform.position - transform.position).x > 0.0f)
                    {
                        if (!manager.attackTarget.isInvincible && manager.enemyAttack.isAttackable)
                        {
                            manager.SetState(EnemyState.ATTACK);
                        }
                    }
                    else if (manager.moveDirection == Vector3.left
                        && (FindObjectOfType<PlayerController>().playerTransform.position - transform.position).x < 0.0f)
                    {
                        if (!manager.attackTarget.isInvincible && manager.enemyAttack.isAttackable)
                        {
                            manager.SetState(EnemyState.ATTACK);
                        }
                    }
                }
                else if (PlayerController.faceDirection == Vector3.left)
                {
                    if (manager.moveDirection == Vector3.right
                        && (FindObjectOfType<PlayerController>().playerTransform.position - transform.position).x > 0.0f)
                    {
                        if (!manager.attackTarget.isInvincible && manager.enemyAttack.isAttackable)
                        {
                            manager.SetState(EnemyState.ATTACK);
                        }
                    }
                    else if (manager.moveDirection == Vector3.left
                        && (FindObjectOfType<PlayerController>().playerTransform.position - transform.position).x < 0.0f)
                    {
                        if (!manager.attackTarget.isInvincible && manager.enemyAttack.isAttackable)
                        {
                            manager.SetState(EnemyState.ATTACK);
                        }
                    }
                }
            }
        }
    }
}
