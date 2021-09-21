using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour {

    public BossManager manager;

    public virtual void BeginState()
    {

    }

    private void Awake()
    {
        manager = GetComponent<BossManager>();
        
    }

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
