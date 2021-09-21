using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour {

    public BossManager manager;

    private void Awake()
    {
        manager = transform.root.GetComponent<BossManager>();
    }
    
    void AttackHitCheck() 
    {
        manager.AttackCheck();
    }
    void AttackHitCheck2()
    {
        manager.AttackCheck2();
    }
    void ChangeState()
    {
        manager.SetState(BossStatus.IDLE);
        
    }
}
