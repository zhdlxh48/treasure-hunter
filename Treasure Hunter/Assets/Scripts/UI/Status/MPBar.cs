using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

#pragma warning disable CS0649

public class MPBar : MonoBehaviour, IBarUnit
{
    #region Components

    private Image mpBarImage;

    #endregion

    private void Awake()
    {
        mpBarImage = GetComponent<Image>();
    }

    public void SetBar(float MAX, float current)
    {
        mpBarImage.fillAmount = Mathf.Clamp(current / MAX, 0.0f, 1.0f);
    }
}
