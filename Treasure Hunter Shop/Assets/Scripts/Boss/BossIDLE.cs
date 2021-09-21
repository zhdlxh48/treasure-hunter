using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIDLE : BossState {

    

    public override void BeginState()
    {
        base.BeginState();
        
    }

    // Use this for initialization
    void Start () {
        GameObject.Find("Artifact").SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if(Time.time >= 3.0f)
            manager.SetState(BossStatus.ATTACK2);
	}
}
