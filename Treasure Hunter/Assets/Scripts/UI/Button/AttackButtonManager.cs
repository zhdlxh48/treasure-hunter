using UnityEngine;
using System.Collections;

public class AttackButtonManager : MonoBehaviour
{
    private PlayerAttack attack;

    public CooldownButton generalAttackCooldown;
    public CooldownButton recallAttackCooldown;

    private void Awake()
    {
        attack = GameObject.FindObjectOfType<PlayerAttack>();

        // Set Button Cooltime
        generalAttackCooldown.cooldownTime = attack.generalAttack.attackDelay;
        recallAttackCooldown.cooldownTime = attack.recallAttack.attackDelay;
    }

    public void GeneralAttackButtonClick()
    {
        StartCoroutine(attack.DelayGeneralAttack());
        generalAttackCooldown.StartCooldown();
    }

    public void RecallAttackButtonClick()
    {
        StartCoroutine(attack.DelayRecallAttack());
        recallAttackCooldown.StartCooldown();
    }
}
