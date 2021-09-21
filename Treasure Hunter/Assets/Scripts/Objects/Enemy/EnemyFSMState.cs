using System;
using UnityEngine;
using System.Collections;

public class EnemyFSMState : MonoBehaviour
{
    public EnemyManager manager;

    private void Awake()
    {
        manager = GetComponent<EnemyManager>();
    }
}
