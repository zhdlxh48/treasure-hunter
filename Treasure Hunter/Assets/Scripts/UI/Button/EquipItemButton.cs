using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipItemButton : MonoBehaviour, IPointerClickHandler
{
    private EquipItemInfo itemInfo;

    private EquipItemManager itemManager;

    private void Awake()
    {
        itemInfo = GetComponent<EquipItemInfo>();

        itemManager = FindObjectOfType<EquipItemManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        itemManager.SetClickedItem(itemInfo);
    }
}
