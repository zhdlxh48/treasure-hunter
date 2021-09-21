using System;
using UnityEngine;
using System.Collections;

public class EnemyDEAD : EnemyFSMState
{
    private void OnEnable()
    {
        manager.enemyAnimator.SetTrigger("Dead");

        StartCoroutine(Dead());
    }

    public IEnumerator Dead()
    {
        Instantiate(manager.dropItem, transform.position + new Vector3(0.0f, 0.5f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

        // TODO: Disappear alpha value set

        yield return new WaitForSeconds(2.0f);

        manager.DestroyEnemy();
    }
}
