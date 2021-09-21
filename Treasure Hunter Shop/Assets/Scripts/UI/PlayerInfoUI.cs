using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    public Slider PlayerHPSlider;

    private void Start()
    {
        PlayerHPSlider.maxValue = playerData.playerHP;
    }

    private void Update()
    {
        PlayerHPSlider.value = playerData.playerHP;
    }
}
