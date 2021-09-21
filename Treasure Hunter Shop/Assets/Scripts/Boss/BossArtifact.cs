using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArtifact : BossState {

	// Use this for initialization
	void Start () {
        
        {
            GameObject.Find("BossAni").SetActive(false);
            GameObject.Find("Artifact").SetActive(true);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
