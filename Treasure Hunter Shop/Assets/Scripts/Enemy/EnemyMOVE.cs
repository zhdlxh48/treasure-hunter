using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMOVE : EnemyState
{
    private float timer = 0.0f;
    private float randomMoveTime;

    //private bool isTrigged = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > randomMoveTime)
        {
            timer = 0.0f;

            manager.SetState(EnemyStatus.IDLE);
        }

        FlipSprite();

        DetectPlayer();
    }

    private void FixedUpdate()
    {
        // 지정한 범위 밖으로 벗어나면 방향을 전환
        //if (transform.position.x < manager.startPositionX - manager.enemyData.moveDistanceLimit || transform.position.x > manager.startPositionX + manager.enemyData.moveDistanceLimit)
        //{
        //    manager.moveDirection = (manager.moveDirection == Vector2.right) ? Vector2.left : Vector2.right;
        //
        //    //Debug.Log("[DEBUG] " + transform.name + "가 MoveLimit에 걸려서 " + manager.moveDirection + "으로 방향을 전환");
        //}

        // 이동구현
        transform.Translate(manager.moveDirection * manager.enemyData.moveSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        randomMoveTime = Random.Range(4.0f, 7.0f);
        manager.moveDirection = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;
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

    private void DetectPlayer()
    {
        if (manager.hit)
        {
            //Debug.Log("[DEBUG] 플레이어를 찾음");
            if (manager.hit.transform.gameObject.GetComponent<PlayerManager>().isDamageable)
            {
                manager.SetState(EnemyStatus.CHASE);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy_Wall과 충돌판정
        if (collision.gameObject.layer == 12)
        {
            //Debug.Log("Col");
            manager.moveDirection = (Vector2.left == manager.moveDirection) ? Vector2.right : Vector2.left;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!isTrigged)
    //    {
    //        if (collision.tag == "Base" || collision.tag == "Floor")
    //        {
    //            manager.moveDirection = (manager.moveDirection == Vector2.right) ? Vector2.left : Vector2.right;
    //
    //            //Debug.Log("[DEBUG] Enemy가 " + collision.name + "에 Trigged Enter 되어서 " + manager.moveDirection + "으로 방향을 전환");
    //
    //            isTrigged = true;
    //        }
    //    }
    //}
}
