using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {


    [FMODUnity.EventRef]
    public string charFootstep = "event:/SFX/Character/Footstep";
    public FMOD.Studio.EventInstance footstep;
    public FMOD.Studio.ParameterInstance runAndJump;

    public string charAttack = "event:/SFX/Character/Attack";
    public FMOD.Studio.EventInstance attack;
    public FMOD.Studio.ParameterInstance monsterAttack;

    public string charHit = "event:/SFX/Character/Hit";
    public FMOD.Studio.EventInstance hit;
    public FMOD.Studio.ParameterInstance monsterType;

    public string charDamage = "event:/SFX/Character/Damage from Zombie";
    public FMOD.Studio.EventInstance damage;
    public FMOD.Studio.ParameterInstance hp;

    // // // // /// //
    //AMB
    public string labAmb = "event:/AMB/Ambience";
    public FMOD.Studio.EventInstance lab;





    // Use this for initialization
    void Start()
    {
        footstep = FMODUnity.RuntimeManager.CreateInstance(charFootstep);
        footstep.getParameter("Run_and_Jump", out runAndJump);
        footstep.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        attack = FMODUnity.RuntimeManager.CreateInstance(charAttack);
        attack.getParameter("Monster Attack", out monsterAttack);
        attack.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        hit = FMODUnity.RuntimeManager.CreateInstance(charHit);
        hit.getParameter("Monster Type", out monsterType);
        hit.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        damage = FMODUnity.RuntimeManager.CreateInstance(charDamage);
        damage.getParameter("HP", out hp);
        damage.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        lab = FMODUnity.RuntimeManager.CreateInstance(labAmb);
        lab.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        lab.start();
    }

    // Update is called once per frame
    void Update()
    {
        footstep.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        attack.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        hit.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        damage.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        lab.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
    }
}
