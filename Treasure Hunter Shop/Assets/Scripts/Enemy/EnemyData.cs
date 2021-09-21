using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnemyData : MonoBehaviour
{
    // x값을 양의 정수로 설정하여, Enemy를 중심으로 한 "x값 만큼의 Ray"가 "양쪽"으로 설정됨
    public Vector3 playerDetectRange;

    public float attackDamage;
    public float attackDelay;
    public float mininumAttackDistance;

    public float enemyHP;

    public float moveSpeed;
    public float moveDistanceLimit;
}
