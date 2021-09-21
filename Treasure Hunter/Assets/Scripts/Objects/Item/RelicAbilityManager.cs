using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RelicAbilityType
{
    REVIVE, BIG_BOME
}

public class RelicAbilityManager : MonoBehaviour
{
    public void ActivateAbility(RelicAbilityType abilityType)
    {
        switch (abilityType)
        {
            case RelicAbilityType.REVIVE:
                ReviveAbility();
                break;
            case RelicAbilityType.BIG_BOME:
                BigBombAblilty();
                break;
        }
    }

    private void ReviveAbility()
    {
        Debug.Log("Revive ability activated");

        FindObjectOfType<PlayerManager>().relic.SetActive(true);    

        FindObjectOfType<PlayerManager>().transform.Find("Relic").GetComponent<Animator>().SetTrigger("UseRelic");
        FindObjectOfType<PlayerManager>().playerAnimator.SetTrigger("Revive");

        FindObjectOfType<PlayerManager>().isWaitUseRelic = false;

        FindObjectOfType<PlayerManager>().playerHP.currentHP = FindObjectOfType<PlayerManager>().playerHP.HP_MAX;
    }

    private void BigBombAblilty()
    {
        Debug.Log("BigBomb ability activated");
    }
}