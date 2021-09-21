using UnityEngine;
using System.Collections;

public class EnemySTOP : EnemyFSMState
{
    private void Awake()
    {
        manager.attackTarget = null;
    }

    void Update()
    {
        StateChange();
    }

    private void StateChange()
    {
        Collider2D[] playerDetect = Physics2D.OverlapBoxAll(transform.position + (Vector3)manager.enemyCollider.offset, manager.enemyAttack.attackRange, 0.0f);

        foreach (var item in playerDetect)
        {
            if (item.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                manager.attackTarget = item.transform.root.GetComponent<PlayerManager>();

                if (!manager.attackTarget.isInvincible && manager.enemyAttack.isAttackable)
                {
                    manager.SetState(EnemyState.ATTACK);
                }
            }
        }
    }
}
