using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipItemType
{
    RELIC, WEAPON
}

[System.Serializable]
public class ShowItemPanelElements
{
    public Image clickedImage;

    public Text clickedItemNameText;
    public Text clickedItemDescText;
}

public class EquipItemManager : MonoBehaviour
{
    public EquipItemType equipType;
    private EquipItemType releaseType;

    public static EquipItemInfo clickedItem;

    public GameObject itemSelectPanel;

    public ShowItemPanelElements clickedItemInfo;

    public ShowItemPanelElements equippedWeaponInfo;
    public bool isWeaponEquipped;
    public ShowItemPanelElements equippedRelicInfo;
    public bool isRelicEquipped;

    public GameObject equipButton;
    public GameObject releaseButton;

    private void Awake()
    {
        InitClickedItem();
        InitEquippedItemState();
        LoadInventoryEquipped();

        itemSelectPanel.SetActive(false);
        releaseButton.SetActive(false);
    }

    private void InitClickedItem()
    {
        clickedItem = null;

        clickedItemInfo.clickedImage.sprite = null;

        clickedItemInfo.clickedItemNameText.text = null;
        clickedItemInfo.clickedItemDescText.text = "아이템을 선택해주세요";
    }

    private void InitEquippedItemState()
    {
        isWeaponEquipped = Inventory.Instance.weaponItemImage != null;
        isRelicEquipped = Inventory.Instance.relicItemImage != null;

        equippedRelicInfo.clickedImage.sprite = null;
        equippedWeaponInfo.clickedImage.sprite = null;
    }

    public void LoadInventoryEquipped()
    {
        equippedWeaponInfo.clickedImage.sprite = Inventory.Instance.weaponItemImage;
        equippedWeaponInfo.clickedItemNameText.text = Inventory.Instance.weaponItemName;
        equippedWeaponInfo.clickedItemDescText.text = Inventory.Instance.weaponItemDesc;

        equippedRelicInfo.clickedImage.sprite = Inventory.Instance.relicItemImage;
        equippedRelicInfo.clickedItemNameText.text = Inventory.Instance.relicItemName;
        equippedRelicInfo.clickedItemDescText.text = Inventory.Instance.relicItemDesc;
    }

    public void SetClickedItem(EquipItemInfo tempItem)
    {
        itemSelectPanel.SetActive(true);
        releaseButton.SetActive(false);

        if (equipType != tempItem.itemType)
        {
            Debug.LogError("The type of the active item attachment tab and the type of the clicked item do not match");
            InitClickedItem();

            return;
        }

        clickedItem = tempItem;

        clickedItemInfo.clickedImage.sprite = clickedItem.itemImage;
        clickedItemInfo.clickedItemNameText.text = clickedItem.itemName;
        clickedItemInfo.clickedItemDescText.text = clickedItem.itemDesc;
    }

    public void ShowEquippedWeaponInfo()
    {
        if (isWeaponEquipped)
        {
            itemSelectPanel.SetActive(true);
            releaseButton.SetActive(true);

            clickedItemInfo.clickedImage.sprite = Inventory.Instance.weaponItemImage;
            clickedItemInfo.clickedItemNameText.text = Inventory.Instance.weaponItemName;
            clickedItemInfo.clickedItemDescText.text = Inventory.Instance.weaponItemDesc;

            releaseType = EquipItemType.WEAPON;
        }
    }

    public void ShowEquippedRelicInfo()
    {
        if (isRelicEquipped)
        {
            itemSelectPanel.SetActive(true);
            releaseButton.SetActive(true);

            clickedItemInfo.clickedImage.sprite = Inventory.Instance.relicItemImage;
            clickedItemInfo.clickedItemNameText.text = Inventory.Instance.relicItemName;
            clickedItemInfo.clickedItemDescText.text = Inventory.Instance.relicItemDesc;

            releaseType = EquipItemType.RELIC;
        }
    }

    public void EquipItem()
    {
        if (itemSelectPanel.activeSelf)
        {
            itemSelectPanel.SetActive(false);
        }

        if (equipType == EquipItemType.WEAPON)
        {
            SaveInInventory(EquipItemType.WEAPON, clickedItem);
            RefreshEquippedItemPanel(equippedWeaponInfo, clickedItem);

            isWeaponEquipped = true;

            Debug.Log("무기를 장착함");
        }
        else
        {
            SaveInInventory(EquipItemType.RELIC, clickedItem);
            RefreshEquippedItemPanel(equippedRelicInfo, clickedItem);

            isRelicEquipped = true;

            Debug.Log("유물을 장착함");
        }

        InitClickedItem();
    }

    private void SaveInInventory(EquipItemType itemType, EquipItemInfo itemInfo)
    {
        if (itemType == EquipItemType.RELIC)
        {
            Inventory.Instance.relicItemType = itemInfo.itemType;
            Inventory.Instance.relicItemImage = itemInfo.itemImage;
            Inventory.Instance.relicItemName = itemInfo.itemName;
            Inventory.Instance.relicItemDesc = itemInfo.itemDesc;
        }
        else
        {
            Inventory.Instance.weaponItemType = itemInfo.itemType;
            Inventory.Instance.weaponItemImage = itemInfo.itemImage;
            Inventory.Instance.weaponItemName = itemInfo.itemName;
            Inventory.Instance.weaponItemDesc = itemInfo.itemDesc;
        }
    }

    private void RefreshEquippedItemPanel(ShowItemPanelElements panelElements, EquipItemInfo itemInfo)
    {
        panelElements.clickedImage.sprite = itemInfo.itemImage;
        panelElements.clickedItemNameText.text = itemInfo.itemName;
        panelElements.clickedItemDescText.text = itemInfo.itemDesc;
    }

    public void ReleaseItem()
    {
        if (releaseType == EquipItemType.RELIC)
        {
            equippedRelicInfo.clickedImage.sprite = null;
            equippedRelicInfo.clickedItemNameText.text = null;
            equippedRelicInfo.clickedItemDescText.text = null;

            Inventory.Instance.relicItemImage = null;
            Inventory.Instance.relicItemName = null;
            Inventory.Instance.relicItemDesc = null;

            isRelicEquipped = false;
        }
        else
        {
            equippedWeaponInfo.clickedImage.sprite = null;
            equippedWeaponInfo.clickedItemNameText.text = null;
            equippedWeaponInfo.clickedItemDescText.text = null;

            Inventory.Instance.weaponItemImage = null;
            Inventory.Instance.weaponItemName = null;
            Inventory.Instance.weaponItemDesc = null;

            isWeaponEquipped = false;
        }

        releaseButton.SetActive(false);
        itemSelectPanel.SetActive(false);
    }
}
