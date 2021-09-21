using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Text coinAmount;

    private void Update()
    {
        coinAmount.text = Inventory.Instance.coin.ToString();
    }

    public void OpenSetting()
    {
        SettingManager.Instance.OpenSetting();
    }

    public void OpenCollectionBook()
    {
        Debug.Log("Opened CollectionBook");
    }

    public void GoAdventure()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void GoShop()
    {
        Debug.Log("Opened Shop");
    }

    public void GoCombine()
    {
        Debug.Log("Opened Combine");
    }
}
