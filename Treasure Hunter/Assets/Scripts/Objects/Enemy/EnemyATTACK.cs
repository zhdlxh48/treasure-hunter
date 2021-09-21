using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemyATTACK : EnemyFSMState
{
    private void OnEnable()
    {
        StartCoroutine(manager.AttackDelay());

        manager.enemyAnimator.SetTrigger("Attack");
    }

    public void Attack()
    {
        manager.attackTarget.SendMessage("ApplyDamage", Random.Range((int)manager.enemyAttack.minAttackDamage, (int)(manager.enemyAttack.maxAttackDamage + 1)));

        manager.SetState(manager.generalState);
    }
}
