using UnityEngine;
using System.Collections;

public class EnemyCHASE : EnemyState
{
    void Update()
    {            
        // 레이캐스트에 플레이어가 잡히지 않았을 때
        if (!manager.hit)
        {
            manager.SetState(EnemyStatus.IDLE);
        }
        else
        {
            if (manager.hit.transform.gameObject.GetComponent<PlayerManager>().isDamageable)
            {
                manager.SetState(EnemyStatus.ATTACK);
            }
            else
            {
                manager.SetState(EnemyStatus.MOVE);
            }
        }

        ChangeDirection();
        FlipSprite();
        CheckDistance();
    }

    private void FixedUpdate()
    {
        // 이동구현
        transform.Translate(manager.moveDirection * manager.enemyData.moveSpeed * Time.deltaTime);
    }

    private void FlipSprite()
    {
        if (manager.moveDirection == Vector2.right)
        {
            manager.enemySprite.flipX = true;
        }
        else if (manager.moveDirection == Vector2.left)
        {
            manager.enemySprite.flipX = false;
        }
    }

    private void ChangeDirection()
    {
        if (manager.hit)
        {
            // 움직이는 방향을 플레이어쪽으로 향하도록 조정
            manager.moveDirection = (manager.hit.transform.position.x - transform.position.x < 0.0f) ? Vector2.left : Vector2.right;
        }
        else
        {
            manager.moveDirection = Vector2.zero;
        }
    }

    private void CheckDistance()
    {
        if (manager.hit)
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
            //Debug.Log("[DEBUG] 레이캐스트로 플레이어가 감지되지 않음");

            manager.SetState(EnemyStatus.IDLE);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // Enemy_Wall과 충돌판정
    //    if (collision.gameObject.layer == 12)
    //    {
    //        ////Debug.Log("Col Chase");
    //        manager.moveDirection = Vector2.zero;
    //    }
    //}
}
