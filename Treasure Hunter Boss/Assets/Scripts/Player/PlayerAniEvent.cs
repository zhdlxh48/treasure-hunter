using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniEvent : MonoBehaviour {

    public PlayerManager manager;

    private void Awake()
    {
        manager = transform.root.GetComponent<PlayerManager>();
    }
    void PlayerAttack()
    {
        manager.CauseDamagetoBoss();
        manager.sound.monsterType.setValue(2.0f);
        manager.sound.hit.start();
    }
}
