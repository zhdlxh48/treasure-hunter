using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArtifact : BossState {

	// Use this for initialization
	void Start () {
        
        {
            manager.bossAni.SetActive(false);
            manager.artefact.SetActive(true);
            //Invoke("ScreenFadeOut", 1.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {

        
        if (manager.player.IsTouching(manager.checkArte))
            Destroy(gameObject);

	}
    //void ScreenFadeOut()
    //{
    //    manager.fadingScreen.SetActive(true);
    //}
}
