using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PetStatus
{
    CALL, MOVE, ATTACK
}

public enum PetClass
{
    BLUE = 0, YELLOW, RED
}

public class PetStateComparer : IEqualityComparer<PetStatus>
{
    public bool Equals(PetStatus x, PetStatus y)
    {
        return (int)x == (int)y;
    }

    public int GetHashCode(PetStatus obj)
    {
        return ((int)obj).GetHashCode();
    }
}

public class PetManager : MonoBehaviour
{
    public Rigidbody2D petRigid;
    public Vector2 JumpState;

    public PetData petData;
    public Animator petAnimator;
    public SpriteRenderer petSprite;

    public GameObject detectEnemy = null;

    private Dictionary<PetStatus, PetState> petStat = new Dictionary<PetStatus, PetState>(new PetStateComparer());

    [SerializeField]
    private PetStatus startStatus = PetStatus.CALL;
    [SerializeField]
    private PetStatus currentStatus;

    //public RaycastHit2D hit;

    public float startPositionX;
    public Vector2 moveDirection;

    private void Awake()
    {
        InitState();

        startPositionX = transform.position.x;
    }

    // Use this for initialization
    void Start () {
        SetState(currentStatus);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void InitState()
    {
        currentStatus = startStatus;

        petStat[PetStatus.CALL] = GetComponentInChildren<PetCALL>();
        petStat[PetStatus.MOVE] = GetComponent<PetMOVE>();
        petStat[PetStatus.ATTACK] = GetComponent<PetATTACK>();
    }

    public void SetState(PetStatus changeStatus)
    {
        foreach (var item in petStat)
        {
            item.Value.enabled = false;
        }

        petStat[changeStatus].enabled = true;
        currentStatus = changeStatus;
        // 개별적 루틴을 사용하는 방법
        //StartCoroutine((enemyStat[changeStatus] as EnemyATTACK).Routine());
    }
}
