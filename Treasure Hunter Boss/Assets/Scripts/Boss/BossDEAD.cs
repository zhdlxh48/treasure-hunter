using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDEAD : BossState {

    float transpert = 1.0f;

    // Use this for initialization
    void Start ()
    {
        
        manager.bossSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        StartCoroutine(FadeOutBoss());
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 4; i++)
        {
            manager.rootAttack[i].SetActive(false);
        }
    }

    private IEnumerator FadeOutBoss()
    {

        while (transpert >= 0.0f)
        {
            manager.bossSprite.color = new Color(1.0f, 1.0f, 1.0f, transpert);

            transpert -= 0.01f;

            yield return new WaitForSeconds(0.03f);
        }

        manager.SetState(BossStatus.ARTIFACT);

        yield break;
    }
}
