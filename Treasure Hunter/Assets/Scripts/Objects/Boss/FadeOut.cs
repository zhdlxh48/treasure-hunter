using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    public Image fadeOutScreen;
    Text missionComplete;
    Color screenColor;
    float time;
    float animTime = 1.5f;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        //missionComplete.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime / animTime;
        screenColor = fadeOutScreen.color;
        screenColor.a = Mathf.Lerp(0f, 0.7f, time);
        fadeOutScreen.color = screenColor;

        if (screenColor.a == 1.0)
        {
            //missionComplete.enabled = true;
        }
	}
}
