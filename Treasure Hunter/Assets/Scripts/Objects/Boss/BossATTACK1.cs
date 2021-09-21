using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATTACK1 : BossState {

    int exceptThisRoot;

    public override void BeginState()
    {
        base.BeginState();

    }

    // Use this for initialization
    void Start()
    {
        
    }
    private void OnEnable()
    {
        RootAttack();
        Debug.Log("CurrentState is Attack1");
        
        //Invoke("ChangeState", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RootAttack()
    {
        exceptThisRoot = Random.Range(0, 4);

        Debug.Log("RootAttack Function Called");

        for (int i = 0; i < 4; i++)
        {
            manager.rootAttack[i].SetActive(true);
        }

        manager.rootAttack[exceptThisRoot].SetActive(false);

        for (int i = 0; i < 4; i++)
        {
            if (manager.rootAttack[i].activeSelf == true) {
                manager.rootAnim[i].Play("Boss_Warning");
                //manager.rootAnim[i].Play("Boss_Attack_1");
            }
        }
    }
    void ChangeState()
    {
        manager.SetState(BossStatus.IDLE);
    }
}
