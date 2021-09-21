using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour {

    public PlayerManager manager;

    private void Awake()
    {
        manager = transform.root.GetComponent<PlayerManager>();
        
    }

    void AttackHitCheck()
    {
        manager.AttackCheck();
    }
}
