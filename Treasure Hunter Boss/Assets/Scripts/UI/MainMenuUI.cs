using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuStatus
{
    MAIN = 0, SHOP, PLAY, FIND_ENTER, ADVENTURE_ENTER, COMBO
}

public class MainMenuUI : MonoBehaviour {

    public GameObject[] menuUIObjects;

    private Dictionary<MenuStatus, GameObject> menuController = new Dictionary<MenuStatus, GameObject>();

    //private SettingManager settingManager;

    private void initMenu()
    {
        menuController[MenuStatus.MAIN] = menuUIObjects[(int)MenuStatus.MAIN];
        menuController[MenuStatus.SHOP] = menuUIObjects[(int)MenuStatus.SHOP];
        menuController[MenuStatus.PLAY] = menuUIObjects[(int)MenuStatus.PLAY];
        menuController[MenuStatus.FIND_ENTER] = menuUIObjects[(int)MenuStatus.FIND_ENTER];
        menuController[MenuStatus.ADVENTURE_ENTER] = menuUIObjects[(int)MenuStatus.ADVENTURE_ENTER];
        menuController[MenuStatus.COMBO] = menuUIObjects[(int)MenuStatus.COMBO];
    }

    private void Awake()
    {
        initMenu();
        //settingManager = GameObject.FindGameObjectWithTag("Setting").GetComponent<SettingManager>();
    }

    private void Start()
    {
        SetMenu(MenuStatus.MAIN);
    }

    public void OnMain()
    {
        SetMenu(MenuStatus.MAIN);
    }

    public void OnPlay()
    {
        SetMenu(MenuStatus.PLAY);
    }

    public void OnEnterAdventure()
    {
        SetMenu(MenuStatus.ADVENTURE_ENTER);
    }

    public void OnEnterFind()
    {
        SetMenu(MenuStatus.FIND_ENTER);
    }

    public void OnShop()
    {
        SetMenu(MenuStatus.SHOP);
    }

    public void SetMenu(MenuStatus changeState)
    {
        foreach (var item in menuController)
        {
            item.Value.SetActive(false);
        }

        menuController[changeState].SetActive(true);
    }

    public void OnCombo()
    {
        SetMenu(MenuStatus.COMBO);
    }
}
