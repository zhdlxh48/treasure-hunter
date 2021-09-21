using UnityEngine;
using System.Collections;

public class PlayerAnimationEvent : MonoBehaviour
{
    private PlayerAttack attack;

    private void Awake()
    {
        attack = GetComponentInParent<PlayerAttack>();
    }

    public void GeneralAttackApply()
    {
        attack.DamageThroughGeneralAttack();
    }

    public void PetRecall()
    {
        attack.RecallPet();
    }
}
