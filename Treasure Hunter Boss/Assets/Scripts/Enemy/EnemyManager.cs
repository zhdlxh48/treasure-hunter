using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStatus
{
    MOVE, CHASE, ATTACK, IDLE, DAMAGE, DIE
}

public class EnemyStateComparer : IEqualityComparer<EnemyStatus>
{
    public bool Equals(EnemyStatus x, EnemyStatus y)
    {
        return (int)x == (int)y;
    }

    public int GetHashCode(EnemyStatus obj)
    {
        return ((int)obj).GetHashCode();
    }
}

public class EnemyManager : MonoBehaviour
{
    public EnemyData enemyData;
    public Animator enemyAnimator;
    public SpriteRenderer enemySprite;

    private Dictionary<EnemyStatus, EnemyState> enemyStat = new Dictionary<EnemyStatus, EnemyState>(new EnemyStateComparer());

    [SerializeField]
    private EnemyStatus startStatus = EnemyStatus.IDLE;
    [SerializeField]
    private EnemyStatus currentStatus;

    public GameObject[] dropItem;

    public RaycastHit2D hit;

    //public float startPositionX;
    public Vector2 moveDirection;

    public bool isMovable;

    private void Awake()
    {
        InitState();

        //startPositionX = transform.position.x;
    }

    private void Start()
    {
        SetState(currentStatus);
    }

    private void Update()
    {
        // 범위 안의 플레이어를 LineCast로 검색
        hit = Physics2D.Linecast(transform.position - enemyData.playerDetectRange, transform.position + enemyData.playerDetectRange, 1 << 9);

        // 탐지 범위 Ray Debug
        Debug.DrawRay(transform.position - enemyData.playerDetectRange, enemyData.playerDetectRange * 2.0f);
    }

    private void InitState()
    {
        currentStatus = startStatus;

        enemyStat[EnemyStatus.IDLE] = GetComponent<EnemyIDLE>();
        enemyStat[EnemyStatus.ATTACK] = GetComponent<EnemyATTACK>();
        enemyStat[EnemyStatus.DAMAGE] = GetComponent<EnemyDAMAGE>();
        enemyStat[EnemyStatus.DIE] = GetComponent<EnemyDIE>();

        // 움직임 관련 FSM
        if (isMovable)
        {
            enemyStat[EnemyStatus.MOVE] = GetComponent<EnemyMOVE>();
            enemyStat[EnemyStatus.CHASE] = GetComponent<EnemyCHASE>();
        }
    }

    public void SetState(EnemyStatus changeStatus)
    {
        foreach (var item in enemyStat)
        {
            item.Value.enabled = false;
        }

        enemyStat[changeStatus].enabled = true;
        currentStatus = changeStatus;
        
        // 개별적 루틴을 사용하는 방법
        //StartCoroutine((enemyStat[changeStatus] as EnemyATTACK).Routine());
    }

    public void ApplyDamage(float playerDamage)
    {
        if (enemyData.enemyHP > 0.0f)
        {
            enemyData.enemyHP -= playerDamage;

            SetState(EnemyStatus.DAMAGE);
        }
    }
}
