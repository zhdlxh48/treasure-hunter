using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

#pragma warning disable CS0649

public class HPBar : MonoBehaviour, IBarUnit
{
    #region Components

    private Image hpBarImage;

    #endregion

    private void Awake()
    {
        hpBarImage = GetComponent<Image>();
    }

    public void SetBar(float MAX, float current)
    {
        hpBarImage.fillAmount = Mathf.Clamp( current / MAX, 0.0f, 1.0f );
    }
}
