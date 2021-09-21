using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour
{
    protected EnemyManager manager;

    private void Awake()
    {
        manager = GetComponent<EnemyManager>();
    }
}
