using System;
using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class EnemyAnimationEvent : MonoBehaviour
{
    private EnemyATTACK attack;
    private EnemyDAMAGE damage;

    private void Awake()
    {
        attack = GetComponentInParent<EnemyATTACK>();
        damage = GetComponentInParent<EnemyDAMAGE>();
    }

    public void Attack()
    {
        attack.Attack();
    }

    public void SternEnd()
    {
        damage.SternEnd();
    }
}
