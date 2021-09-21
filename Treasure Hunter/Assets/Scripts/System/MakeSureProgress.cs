using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using UnityEngine.Events;

public enum MakeSureWindowType
{
    ADVENTURE_STOP = 0
}

[System.Serializable]
public class MakeSureWindowContents
{
    public string title;
    [TextArea(2, 3)]
    public string desc;
}

public class MakeSureProgress : MonoSingleton<MakeSureProgress>
{
    #region Variables

    public GameObject checkWindowUI;
    public Button button;

    private IEnumerator toProceedFunc;

    #endregion

    #region Components

    public Text titleText;
    public Text descText;

    #endregion

    #region Text Offsets

    private Dictionary<MakeSureWindowType, MakeSureWindowContents> makeSureWindowOffsets;

    [SerializeField]
    private MakeSureWindowType currentWindowType;

    [SerializeField]
    private MakeSureWindowContents adventureStopText;


    #endregion

    #region Event Functions

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(checkWindowUI);

        makeSureWindowOffsets = new Dictionary<MakeSureWindowType, MakeSureWindowContents>();

        InitWindowTextOffset();

        // Initialize text with current Type
        SetWindowType(currentWindowType);

        checkWindowUI.SetActive(false);
    }

    #endregion

    #region Action Functions

    /// <summary>
    /// Store and initialize text offsets in "MakeSureWindowOffset"
    /// </summary>
    private void InitWindowTextOffset()
    {
        makeSureWindowOffsets[MakeSureWindowType.ADVENTURE_STOP] = adventureStopText;
    }

    /// <summary>
    /// Set the title and description text offset type of the "MakeSure" window
    /// </summary>
    /// <param name="windowType"> "MakeSure" window's type </param>
    public void SetWindowType(MakeSureWindowType windowType)
    {
        currentWindowType = windowType;

        titleText.text = makeSureWindowOffsets[windowType].title;
        descText.text = makeSureWindowOffsets[windowType].desc;
    }

    /// <summary>
    /// Prepare a window to check before the work begins
    /// </summary>
    /// <param name="func"> The IEnumerator to progress the work func </param>
    /// <param name="windowType"> Select the type of window to display </param>
    public void ReadyProgress(IEnumerator func, MakeSureWindowType windowType)
    {
        toProceedFunc = func;
        SetWindowType(windowType);

        checkWindowUI.SetActive(true);
    }

    /// <summary>
    /// Run the function that contains the content to work with
    /// </summary>
    public void DoProgress()
    {
        StartCoroutine(toProceedFunc);
    }

    /// <summary>
    /// Initialize toProceedFunc to null and close the window
    /// </summary>
    public void CancelProgress()
    {
        toProceedFunc = null;

        checkWindowUI.SetActive(false);
    }

    public void CloseWindow()
    {
        toProceedFunc = null;

        checkWindowUI.SetActive(false);
    }

    #endregion
}
