using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItemSelectManager : MonoBehaviour
{
    public GameObject battleItemWindow;

    public ScrollRect scrollRect;

    public GameObject relicContent;
    private RectTransform relicTransform;
    public GameObject weaponContent;
    private RectTransform weaponTransform;

    private EquipItemManager equipItemManager;

    private void Awake()
    {
        battleItemWindow.SetActive(false);

        relicTransform = relicContent.GetComponent<RectTransform>();
        weaponTransform = weaponContent.GetComponent<RectTransform>();

        equipItemManager = FindObjectOfType<EquipItemManager>();

        relicContent.SetActive(true);
        weaponContent.SetActive(false);
    }

    public void BattleItemWindowOpen()
    {
        battleItemWindow.SetActive(true);
        equipItemManager.LoadInventoryEquipped();
    }

    public void BattleItemWindowClose()
    {
        battleItemWindow.SetActive(false);
    }

    public void RelicClick()
    {
        equipItemManager.equipType = EquipItemType.RELIC;

        relicContent.SetActive(true);
        weaponContent.SetActive(false);

        scrollRect.content = relicTransform;
    }

    public void WeaponClick()
    {
        equipItemManager.equipType = EquipItemType.WEAPON;

        relicContent.SetActive(false);
        weaponContent.SetActive(true);

        scrollRect.content = weaponTransform;
    }
}
