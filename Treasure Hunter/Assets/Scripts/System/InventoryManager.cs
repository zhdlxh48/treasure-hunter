using System;
using System.Collections;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private void Awake()
    {
        LoadInventory();

        DontDestroyOnLoad(gameObject);
    }

    public static void AddCoin(int coinValue)
    {
        Inventory.Instance.coin += coinValue;
    }

    public static void AddLoot(LootType lootType, int lootValue)
    {
        Inventory.Instance.loot[(int)lootType] += lootValue;
    }

    public static void PushTempToInventory()
    {
        PlayerManager manager = FindObjectOfType<PlayerManager>();

        Inventory.Instance.coin = manager.coin;

        for (int i = 0; i < Inventory.Instance.loot.Length; i++)
        {
            Inventory.Instance.loot[i] = manager.loot[i];
        }

        Debug.Log("PushTempToInventory() - Coin : " + manager.coin);
        Debug.Log("PushTempToInventory() - Coin : " + Inventory.Instance.coin);

        SaveInventory();
    }

    public static void LoadInventory()
    {
        Debug.Log("LoadInventory() - Coin : " + PlayerPrefs.GetInt("player_coin_value"));
        Inventory.Instance.coin = PlayerPrefs.GetInt("player_coin_value");

        Inventory.Instance.loot[(int)LootType.FLOWER] = PlayerPrefs.GetInt("player_loot_flower_value");
        Inventory.Instance.loot[(int)LootType.LEATHER] = PlayerPrefs.GetInt("player_loot_leather_value");
        Inventory.Instance.loot[(int)LootType.MARBLE] = PlayerPrefs.GetInt("player_loot_marble_value");
        Inventory.Instance.loot[(int)LootType.SLATE] = PlayerPrefs.GetInt("player_loot_slate_value");
    }

    public static void SaveInventory()
    {
        Debug.Log("SaveInventory() - Coin : " + Inventory.Instance.coin);
        PlayerPrefs.SetInt("player_coin_value", Inventory.Instance.coin);

        PlayerPrefs.SetInt("player_loot_flower_value", Inventory.Instance.loot[(int)LootType.FLOWER]);
        PlayerPrefs.SetInt("player_loot_leather_value", Inventory.Instance.loot[(int)LootType.LEATHER]);
        PlayerPrefs.SetInt("player_loot_marble_value", Inventory.Instance.loot[(int)LootType.MARBLE]);
        PlayerPrefs.SetInt("player_loot_slate_value", Inventory.Instance.loot[(int)LootType.SLATE]);
    }
}
