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

    /// <summary>
    /// //////////스탯 바꾸기
    /// </summary>

    public BossStatus startStatus;
    public BossStatus currentStatus;

    public float bossHP;
    public float attackDamage1;
    public float attackDamage2;

    public Rigidbody2D player;
    public Animator anim;
    public Animator[] rootAnim;

    public SpriteRenderer bossSprite;

    public LayerMask attack2Layer;
    public GameObject bossAni;
    public GameObject artefact;
    public BoxCollider2D checkArte;
    public GameObject[] rootAttack;

    public GameObject fadingScreen;

    public bool isTouched = false;

    public LayerMask attack1Layer;

    Dictionary<BossStatus, BossState> states = new Dictionary<BossStatus, BossState>();

    private void Awake()
    {

        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        

        attack2Layer = LayerMask.GetMask("AttackCheck_2");
        attack1Layer = LayerMask.GetMask("AttackCheck_1");
        bossAni = GameObject.Find("BossAni");
        artefact = GameObject.Find("Artifact");
        checkArte = artefact.GetComponent<BoxCollider2D>();
        //rootAttack = GameObject.FindGameObjectsWithTag("Root");
        fadingScreen = GameObject.Find("Canvas");

        int num = 0;

        for (int i = 0; i < 8; i++)
        {
            if (rootAttack[i].GetComponent<Animator>())
                rootAnim[num++] = rootAttack[i].GetComponent<Animator>();
        }

        bossSprite = transform.Find("BossAni").GetComponentInChildren<SpriteRenderer>();

        states.Add(BossStatus.IDLE, GetComponent<BossIDLE>());
        states.Add(BossStatus.ATTACK1, GetComponent<BossATTACK1>());
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

    }

    public void AttackCheck()
    {
        if (player.IsTouchingLayers(attack1Layer) && currentStatus == BossStatus.ATTACK1)
            player.SendMessage("ApplyDamage", attackDamage1);

    }
    public void AttackCheck2()
    {
        if (player.IsTouchingLayers(attack2Layer) && currentStatus == BossStatus.ATTACK2)
            player.SendMessage("ApplyDamage", attackDamage2);
    }

    void ApplyDamage(float damage)
    {
        bossHP -= damage;

        StartCoroutine(attackAlphaChange());
        
        if (bossHP <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                rootAttack[i].SetActive(false);
            }

            SetState(BossStatus.DEAD);
            Debug.Log(name + ":Dead");
        }
    }

    private IEnumerator attackAlphaChange()
    {
        bossSprite.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);

        yield return new WaitForSeconds(1.0f);

        bossSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        yield break;
    }

    // Update is called once per frame
    void Update () {
        if (bossHP <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                rootAttack[i].SetActive(false);
            }

            SetState(BossStatus.DEAD);
            Debug.Log(name + ":Dead");
        }
    }

    public void GoOnShow()
    {
        StartCoroutine(WindowShow());
    }

    public IEnumerator WindowShow()
    {
        isTouched = true;

        yield return new WaitForSeconds(2.0f);

        fadingScreen.SetActive(true);
    }
}

//기존 함수랑 합치기
//임시함수 지우기
