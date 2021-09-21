using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    #region Variables

    public GameObject pauseUI;

    #endregion

    #region Event Functions

    private void Awake()
    {
        pauseUI.SetActive(false);
    }

    #endregion

    #region Action Functions

    /// <summary>
    /// Pause game and open pause window
    /// </summary>
    public void OpenPause()
    {
        pauseUI.SetActive(true);

        Time.timeScale = 0.0f;
    }

    /// <summary>
    /// Run the game normally and close the pause window
    /// </summary>
    public void Continue()
    {
        pauseUI.SetActive(false);

        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Open the Setting window
    /// </summary>
    public void OpenSetting()
    {
        SettingManager.Instance.OpenSetting();
    }

    /// <summary>
    /// Finish the game and move to "MainScene"
    /// </summary>
    public void GoMain()
    {
        if (MakeSureProgress.Instance == null) { }

        MakeSureProgress.Instance.ReadyProgress(ChangeSceneToMain(), MakeSureWindowType.ADVENTURE_STOP);
    }

    /// <summary>
    /// Finish the game and move to "StageSelectScene"
    /// </summary>
    public void GoStageSelect()
    {
        if (MakeSureProgress.Instance == null) { }

        MakeSureProgress.Instance.ReadyProgress(ChangeSceneToStageSelect(), MakeSureWindowType.ADVENTURE_STOP);
    }

    #endregion

    #region IEnumerator Functions

    /// <summary>
    /// It is a IEnumerator function to move to "MainScene"
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeSceneToMain()
    {
        AsyncOperation changeOperation = SceneManager.LoadSceneAsync("MainScene");
        
        // TODO: 씬 전환에 로딩을 위한 시각적 효과 추가

        while (!changeOperation.isDone)
        {
            yield return null;
        }

        MakeSureProgress.Instance.CloseWindow();

        yield break;
    }

    /// <summary>
    /// It is a IEnumerator function to move to "StageSelectScene"
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeSceneToStageSelect()
    {
        AsyncOperation changeOperation = SceneManager.LoadSceneAsync("StageSelectScene");

        // TODO: 씬 전환에 로딩을 위한 시각적 효과 추가

        while (!changeOperation.isDone)
        {
            yield return null;
        }

        MakeSureProgress.Instance.CloseWindow();

        yield break;
    }

    #endregion
}
