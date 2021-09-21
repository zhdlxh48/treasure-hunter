using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour {

    [FMODUnity.EventRef]
    public string bossMonsterAttack = "event:/SFX/Monsters/Boss Monster/Attack";
    public FMOD.Studio.EventInstance bossAttack;
    public FMOD.Studio.ParameterInstance attackType;

    public string bossMonsterDead = "event:/SFX/Monsters/Boss Monster/Dead";
    public FMOD.Studio.EventInstance bossDead;

    public string bossArtifact = "event:/SFX/Monsters/Boss Monster/Artifact";
    public FMOD.Studio.EventInstance artifact;
    public FMOD.Studio.ParameterInstance dropAndGet;



    // Use this for initialization
    void Start () {
        bossAttack = FMODUnity.RuntimeManager.CreateInstance(bossMonsterAttack);
        bossAttack.getParameter("Attack Type", out attackType);
        bossAttack.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        bossDead = FMODUnity.RuntimeManager.CreateInstance(bossMonsterDead);
        bossDead.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        artifact = FMODUnity.RuntimeManager.CreateInstance(bossArtifact);
        artifact.getParameter("Drop and Get", out dropAndGet);
        artifact.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
