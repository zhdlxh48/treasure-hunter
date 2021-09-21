using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIDLE : BossState {

    float random;

    public override void BeginState()
    {
        base.BeginState();
        
    }

    // Use this for initialization
    void Start () {
        manager.artefact.SetActive(false);
        manager.fadingScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

    }

    private void OnEnable()
    {
       
        for (int i = 0; i<4;i++)
        {
            manager.rootAttack[i].SetActive(false);
        }
        Invoke("ChangeState", Random.Range(1.5f,2.0f));
    }
    void ChangeState()
    {
        random = Random.Range(0.0f, 10.0f);
        if(random>5.0f)
            manager.SetState(BossStatus.ATTACK1);
        else
            manager.SetState(BossStatus.ATTACK2);
    }
}
