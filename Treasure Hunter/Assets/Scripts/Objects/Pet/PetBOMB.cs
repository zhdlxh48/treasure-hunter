using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBOMB : PetFSMState
{
    #region Event Functions

    public void OnEnable()
    {
        manager.petAnimator.SetTrigger("Bomb");
    }

    public void BombAttack()
    {
        Collider2D[] enemyDetect = Physics2D.OverlapCircleAll(transform.position + new Vector3(0.0f, 0.5f), 1.5f);

        foreach (var enemy in enemyDetect)
        {
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                enemy.transform.root.SendMessage("ApplyDamage", manager.petSetting.attackDamage);
            }
        }
    }

    #endregion
}
