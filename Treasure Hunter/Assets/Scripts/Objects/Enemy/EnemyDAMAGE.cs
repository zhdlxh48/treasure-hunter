using System;
using UnityEngine;
using System.Collections;

public class EnemyDAMAGE : EnemyFSMState
{
    private void OnEnable()
    {
        manager.enemyAnimator.SetTrigger("Damage");

        if (manager.enemyHP.currentHP <= 0.0f)
        {
            manager.enemyAnimator.SetBool("isDead", true);
        }
    }

    //private void Update()
    //{
    //    StateChange();
    //}

    public void SternEnd()
    {
        StateChange();
    }

    private void StateChange()
    {
        if (manager.enemyHP.currentHP <= 0.0f)
        {
            manager.SetState(EnemyState.DIE);
        }
        else
        {
            manager.SetState(manager.generalState);
        }
    }
}
