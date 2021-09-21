using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour
{
    protected EnemyManager manager;
    protected EnemySound sound;

    private void Awake()
    {
        manager = GetComponent<EnemyManager>();
        sound = GetComponent<EnemySound>();
        
    }
}
