using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject settingMenu;

    private void Awake()
    {
        settingMenu.SetActive(false);
    }

    public void OpenSetting()
    {
        settingMenu.SetActive(true);
    }

    public void CloseSetting()
    {
        settingMenu.SetActive(false);
    }

    public void ApplySetting()
    {
        // TODO: 정보를 저장하는 부분
        settingMenu.SetActive(false);
    }
}
