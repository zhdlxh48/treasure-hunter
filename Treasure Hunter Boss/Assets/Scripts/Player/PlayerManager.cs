using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerStateCase
{
    IDLE = 0,
    MOVE,
    ATTACK,
    DAMAGE, 
    DIE
}

public enum PlayerAttackCase
{
    NOTHING = 0, 
    GENERAL, 
    RECALL
}

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;

    private Dictionary<PlayerStateCase, PlayerState> playerStateDic = new Dictionary<PlayerStateCase, PlayerState>();
    
    public SpriteRenderer playerSprite;
    public Animator playerAnimator;

    // values related to player state
    [SerializeField]
    private PlayerStateCase startState;
    [SerializeField]
    public PlayerStateCase currentState;

    // values related to attack status
    public PlayerAttackCase attackState;

    // Object related to movementhjg
    public Transform moveObject;

    // Settings related to movement
    //[HideInInspector]
    public Vector3 moveDirection;

    // Status values ​​related to movement and jump
    //[HideInInspector]
    public bool isMovable;

    public float generalAttackTimer;
    public float recallAttackTimer;

    public bool isAttackable;

    [SerializeField]
    private float invincibleTime;
    public bool isDamageable;

    public GameObject[] petObject;
    public PetClass petClass;

    //********************tempfunc************

    public Rigidbody2D player;
    public GameObject boss;
    public LayerMask attack2Layer;
    public PlayerData data;
    //***********************

    public PlayerSound sound;
    public BossManager bossManager;
    public Animator anim;

    private void Awake()
    {
        currentState = startState;

        isMovable = true;
        isAttackable = true;
        isDamageable = true;

        InitState();
        SetState(startState);

        //////////temp///////
        player = GetComponent<Rigidbody2D>();
        boss = GameObject.FindGameObjectWithTag("BossEnemy");
        attack2Layer = LayerMask.GetMask("AttackCheck_2");
        //*///////////////////////
        sound = GetComponent<PlayerSound>();
        bossManager = boss.GetComponent<BossManager>();
        anim = GetComponentInChildren<Animator>(); 

    }

    private void Start()
    {
        PlayButtonUI.Instance.OnMoveButton += value => moveDirection = value;
        PlayButtonUI.Instance.OnAttackButton += value => attackState = value;
    }

    private void FixedUpdate()
    {
        playerStateDic[currentState].VFixedUpdate();
    }

    private void Update()
    {
        playerStateDic[currentState].VUpdate();

        TimeCheck();
    }

    private void InitState()
    {
        playerStateDic[PlayerStateCase.IDLE] = GetComponent<PlayerIDLE>();
        playerStateDic[PlayerStateCase.MOVE] = GetComponent<PlayerMOVE>();
        playerStateDic[PlayerStateCase.ATTACK] = GetComponent<PlayerATTACK>();
        playerStateDic[PlayerStateCase.DAMAGE] = GetComponent<PlayerDAMAGE>();
        playerStateDic[PlayerStateCase.DIE] = GetComponent<PlayerDIE>();
    }

    public void SetState(PlayerStateCase changeState)
    {
        currentState = changeState;

        foreach (var item in playerStateDic)
        {
            item.Value.enabled = false;
        }

        playerStateDic[currentState].enabled = true;
    }

    private void TimeCheck()
    {
        if (generalAttackTimer <= playerData.generalAttackDelay)
        {
            generalAttackTimer += Time.deltaTime;
        }
        if (recallAttackTimer <= playerData.recallAttackDelay)
        {
            recallAttackTimer += Time.deltaTime;
        }
    }

    public void ApplyDamage(float enemyDamage)
    {
        if (playerData.playerHP > 0.0f)
        {
            if (isDamageable)
            {
                playerData.playerHP -= enemyDamage;

                SetState(PlayerStateCase.DAMAGE);
            }
        }
    }
    public void CauseDamagetoBoss()
    {
        if (bossManager.bossHP > 0.0f && player.IsTouchingLayers(attack2Layer))
        {
            boss.SendMessage("ApplyDamage", playerData.attackDamage);
            GameObject.Find("BossEffect").GetComponent<Animator>().Play("Boss_Effect");
            
        }
    }

    public IEnumerator InvincibleState()
    {
        Debug.Log("공격 받을 수 없음");

        StartCoroutine(SetToCanNotAttack());

        isDamageable = false;
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.75f);

        yield return new WaitForSeconds(invincibleTime);
        
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1.0f);
        isDamageable = true;


        Debug.Log("공격 받을 수 잇음");

        yield break;
    }

    public IEnumerator SetToCanNotAttack()
    {
        Debug.Log("공격 할 수 없음");
        isAttackable = false;

        yield return new WaitForSeconds(invincibleTime / 2.0f);

        isAttackable = true;
        Debug.Log("공격 할 수 잇음");
        yield break;
    }
}
