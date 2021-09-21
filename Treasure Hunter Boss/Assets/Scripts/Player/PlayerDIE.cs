using UnityEngine;
using System.Collections;

public class PlayerDIE : PlayerState
{
    private Coroutine dead;
    private WaitForSeconds transparantTime;

    private void OnEnable()
    {
        transparantTime = new WaitForSeconds(0.005f);

        manager.playerAnimator.SetInteger("SetState", (int)manager.currentState);

        Debug.Log((int)manager.currentState);

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
        Debug.Log("쥬금 과정");

        manager.playerSprite.color = new Color(manager.playerSprite.color.r, manager.playerSprite.color.g, manager.playerSprite.color.b, 1.0f);
        
        while (manager.playerSprite.color.a >= 0.0f)
        {
            manager.playerSprite.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f);



            Debug.Log("돌아가니asdasdasd?");
            yield return transparantTime;

            Debug.Log("돌아가니?");
        }
        // 게임 씬이 다시 로드되도록 수정
        Destroy(gameObject);
    }
}
