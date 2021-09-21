using System;
using UnityEngine;
using System.Collections;
using Core;

public class Inventory : MonoSingleton<Inventory>
{
    [Header("Player Inventory")]
    public int coin;
    public int[] loot;

    [Header("Equipped Relic Item")]

    public EquipItemType relicItemType;

    public Sprite relicItemImage;

    public string relicItemName;
    public string relicItemDesc;

    [Header("Equipped Weapon Item")]

    public EquipItemType weaponItemType;

    public Sprite weaponItemImage;

    public string weaponItemName;
    public string weaponItemDesc;

    protected override void Awake()
    {
        base.Awake();

        loot = new int[4];
    }
}
