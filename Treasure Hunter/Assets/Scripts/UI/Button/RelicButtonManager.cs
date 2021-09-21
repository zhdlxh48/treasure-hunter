using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RelicButtonManager : MonoBehaviour
{
    public CooldownButton relicUseCooldown;
    private RelicAbilityManager ability;

    public RelicItem relicItem;

    private PlayerManager manager;

    public Text relicRemainText;

    private void Awake()
    {
        ability = FindObjectOfType<RelicAbilityManager>();

        relicUseCooldown.cooldownTime = relicItem.relicUseCooltime;

        relicRemainText.text = relicItem.relicRemainNum.ToString();

        manager = FindObjectOfType<PlayerManager>();
    }

    public void UseRelic()
    {
        if (manager.isWaitUseRelic)
        {
            if (relicItem.relicRemainNum > 0)
            {
                relicRemainText.text = (--relicItem.relicRemainNum).ToString();

                relicUseCooldown.StartCooldown();

                ability.ActivateAbility(relicItem.relicAbilityType);
            }
        }
    }
}
