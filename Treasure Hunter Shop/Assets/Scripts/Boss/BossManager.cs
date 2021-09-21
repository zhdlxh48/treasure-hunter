using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossStatus
{
    IDLE = 0,
    ATTACK1,
    ATTACK2,
    DEAD,
    ARTIFACT
}

public class BossManager : MonoBehaviour {

    public BossStatus startStatus;
    public BossStatus currentStatus;

    public float bossHP;
    public float attackDamage1;
    public float attackDamage2;

    public Rigidbody2D player;
    public Animator anim;
    public LayerMask layermask;

    Dictionary<BossStatus, BossState> states = new Dictionary<BossStatus, BossState>();

    private void Awake()
    {

        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        layermask = LayerMask.GetMask("Enemy");

        states.Add(BossStatus.IDLE, GetComponent<BossIDLE>());
        states.Add(BossStatus.ATTACK1, GetComponent<BossATTACK>());
        states.Add(BossStatus.ATTACK2, GetComponent<BossATTACK2>());
        states.Add(BossStatus.DEAD, GetComponent<BossDEAD>());
        states.Add(BossStatus.ARTIFACT, GetComponent<BossArtifact>());

    }

    // Use this for initialization
    void Start () {
        SetState(startStatus);
	}
	
    public void SetState(BossStatus newStatus)
    {
        foreach(BossState Bst in states.Values)
        {
            Bst.enabled = false;
        }
        currentStatus = newStatus;
        states[currentStatus].enabled = true;
        states[currentStatus].BeginState();
        anim.SetInteger("CurrState", (int)currentStatus);
        Debug.Log(anim.GetInteger("CurrState"));
    }

    public void AttackCheck()
    {
        if(player.IsTouchingLayers(layermask))
            player.SendMessage("ApplyDamage", attackDamage2);
    }

    void ApplyDamagetoBoss(float damage)
    {
        bossHP -= damage;
        Debug.Log("[" + name + "] took damage : " + damage);
        if (bossHP <= 0)
        {
            Debug.Log(name + ":Dead");
        }
    }

    // Update is called once per frame
    void Update () {
        if (bossHP == 0)
        {
            SetState(BossStatus.DEAD);
        }
        if (Time.time >= 10.0f)
        {
            SetState(BossStatus.DEAD);
        }
	}
}

//기존 함수랑 합치기
//공격1 구현
//임시함수 지우기
