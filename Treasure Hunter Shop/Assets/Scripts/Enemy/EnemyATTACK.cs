using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATTACK : EnemyState
{
    private float timer = 0.0f;
    bool attack = false;
    bool going = false;

    private void OnEnable()
    {
        attack = false;
        going = false;
        Attack();
    }

    private void OnDisable()
    {

    }

    public void Attack()
    {
        if (manager.hit.transform.gameObject.GetComponent<PlayerManager>().isDamageable)
        {
            manager.enemyAnimator.SetTrigger("isAttack");
            StartCoroutine(SleepScript());

            manager.hit.transform.gameObject.GetComponent<PlayerManager>().SendMessage("ApplyDamage", manager.enemyData.attackDamage);

            while (manager.enemyData.attackDelay > timer)
            {
                timer += Time.deltaTime;
            }
            attack = true;
        }
        else
        {
            manager.SetState(EnemyStatus.MOVE);
        }        
    }

    private void Update()
    {
        if (going)
            CheckDistance();
    }

    private void CheckDistance()
    {
        if (manager.hit)
        {
            float betweenDistance = manager.hit.transform.position.x - transform.position.x;

            //Debug.Log("[DEBUG] Player와 Enemy의 X축 간격 : " + betweenDistance);

            if (betweenDistance <= manager.enemyData.mininumAttackDistance && betweenDistance >= -manager.enemyData.mininumAttackDistance && attack == true)
            {
                //Debug.Log("[DEBUG] 거리가 가까워 ATTACK으로 전환");
                attack = false;
                manager.SetState(EnemyStatus.ATTACK);
            }
            else
            {
                if (manager.isMovable)
                {
                    //Debug.Log("[DEBUG] 범위 밖에 Player가 존재해 CHASE로 추적");
                    if (manager.hit.transform.gameObject.GetComponent<PlayerManager>().isDamageable)
                    {
                        manager.SetState(EnemyStatus.CHASE);
                    }
                    else
                    {
                        //플레이어 무적상태
                        manager.SetState(EnemyStatus.MOVE);
                    }
                }
                else
                {
                    // 움직일 수 없는 Enemy이므로, 범위 밖으로 나가면 IDLE로 바로 변경
                    manager.SetState(EnemyStatus.IDLE);
                }
            }
        }
        else
        {
            //Debug.Log("[DEBUG] 레이캐스트로 플레이어가 감지되지 않음");

            manager.SetState(EnemyStatus.IDLE);
        }
    }

    IEnumerator SleepScript()
    {
        yield return new WaitForSeconds(0.8f);
        going = true;
    }
}
