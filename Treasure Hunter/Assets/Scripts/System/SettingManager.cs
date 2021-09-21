using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

public class SettingManager : MonoSingleton<SettingManager>
{
    #region Variables

    public GameObject settingUI;

    #endregion

    #region Event Functions

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(settingUI);

        settingUI.SetActive(false);
    }

    #endregion

    #region Action Functions

    public void OpenSetting()
    {
        settingUI.SetActive(true);
    }

    public void CloseSetting()
    {
        settingUI.SetActive(false);
    }

    public void PlayCredit()
    {
        // TODO: Credits Scene Add
    }

    public void ExitGame()
    {
        InventoryManager.PushTempToInventory();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.Quit();
#endif
    }

    #endregion
}