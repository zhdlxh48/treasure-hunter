using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDEAD : BossState {

    float time;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time += Time.deltaTime;
        if (time >= 2.0f)
            manager.SetState(BossStatus.ARTIFACT);
    }
}
