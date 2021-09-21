using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour {

    public BossManager manager;

    private void Awake()
    {
        manager = transform.root.GetComponent<BossManager>();
    }
    
    void AttackHitCheck() //두 번씩 호출되는 현상 수정하기
    {
        manager.AttackCheck();
    }
}
