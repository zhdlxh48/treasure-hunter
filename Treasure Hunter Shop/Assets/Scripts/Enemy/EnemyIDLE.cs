using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIDLE : EnemyState
{
    void Update()
    {
        DetectPlayer();
    }

    private void OnEnable()
    {
        float waitTime = Random.Range(0.5f, 1.5f);

        if (manager.isMovable)
        {
            StartCoroutine(NextStatus(waitTime));
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator NextStatus(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        EnemyStatus nextStatus = Random.Range(0, 5) == 0 ? EnemyStatus.IDLE : EnemyStatus.MOVE;

        //Debug.Log("[DEBUG] " + waitTime + "초 후에 " + nextStatus.ToString() + "로 전환");

        manager.SetState(nextStatus);
    }

    private void DetectPlayer()
    {
        if (manager.hit)
        {
            //Debug.Log("[DEBUG] 플레이어를 찾음");

            // 움직임이 없는 Enemy의 경우 IDLE과 ATTACK만 있으므로, IDLE에서 ATTACK판단을 처리
            if (!manager.isMovable)
            {
                // 플레이어와 Enemy가 가까이 있을 때 처리
                float betweenDistance = manager.hit.transform.position.x - transform.position.x;

                //Debug.Log("[DEBUG] Player와 Enemy의 X축 간격 : " + betweenDistance);

                if (betweenDistance <= manager.enemyData.mininumAttackDistance && betweenDistance >= -manager.enemyData.mininumAttackDistance)
                {
                    if (manager.hit.transform.gameObject.GetComponent<PlayerManager>().isDamageable)
                    {
                        manager.SetState(EnemyStatus.ATTACK);
                    }
                }
            }
            else
            {
                manager.SetState(EnemyStatus.CHASE);
            }
        }
    }
}
