using UnityEngine;
using System.Collections;

public class EnemyDIE : EnemyState
{
    private Coroutine dead;

    private void OnEnable()
    {
        manager.enemyAnimator.SetTrigger("isDead");

        dead = StartCoroutine(Dead());
    }

    private void OnDisable()
    {
        if (dead != null)
        {
            StopCoroutine(dead);
        }
    }

    private IEnumerator Dead()
    {
        Instantiate(manager.dropItem[Random.Range(0, manager.dropItem.Length)], transform.position, transform.rotation);

        while (manager.enemySprite.color.a >= 0.0f)
        {
            manager.enemySprite.color -= new Color(0.0f, 0.0f, 0.0f, 0.01f);

            yield return new WaitForSeconds(0.005f);
        }

        // 게임 씬이 다시 로드되도록 수정
        Destroy(gameObject);
    }
}
