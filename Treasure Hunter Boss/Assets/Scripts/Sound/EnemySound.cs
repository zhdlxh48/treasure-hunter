using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour {

    [FMODUnity.EventRef]
    public string charHit = "event:/SFX/Character/Hit";
    public FMOD.Studio.EventInstance hit;
    public FMOD.Studio.ParameterInstance monsterType;

    public string zmonsterAttack = "event:/SFX/Monsters/Monster Zombie/Zombie_Attack";
    public FMOD.Studio.EventInstance monAttack;
    public FMOD.Studio.ParameterInstance attack;

    // Use this for initialization
    void Start () {
        hit = FMODUnity.RuntimeManager.CreateInstance(charHit);
        hit.getParameter("Monster Type", out monsterType);
        hit.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        monAttack = FMODUnity.RuntimeManager.CreateInstance(zmonsterAttack);
        monAttack.getParameter("Attack", out attack);
        monAttack.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
