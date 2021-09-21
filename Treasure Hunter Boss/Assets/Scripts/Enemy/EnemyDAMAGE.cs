using UnityEngine;
using System.Collections;

public class EnemyDAMAGE : EnemyState
{
    private Coroutine damage;

    private void OnEnable()
    {
        damage = StartCoroutine(Damage());
        sound.hit.start();
    }
    private void Start()
    {
        
    }

    private void OnDisable()
    {
        StopCoroutine(damage);
    }

    private void Update()
    {
        isDead();
    }

    private IEnumerator Damage()
    {
        manager.enemyAnimator.SetTrigger("Damaged");

        yield return new WaitForSeconds(1.0f);

        DetectPlayer();
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
        else
        {
            manager.SetState(EnemyStatus.MOVE);
        }
    }

    public void isDead()
    {
        if (manager.enemyData.enemyHP <= 0)
        {
            manager.SetState(EnemyStatus.DIE);
        }
    }
}
