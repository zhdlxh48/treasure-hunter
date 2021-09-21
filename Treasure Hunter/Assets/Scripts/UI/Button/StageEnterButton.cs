using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum StageEnterTextState
{
    BEFORE, AFTER
}

[System.Serializable]
public class StageEnterText
{
    public Text beforeText;
    public Text afterText;
}

public class StageEnterButton : MonoBehaviour, IPointerClickHandler
{
    //public static bool isButtonClicked;

    public StageEnterText swapTexts;
    public Button enterButton;

    public string moveStageName;

    public bool isStageUnlocked;

    [SerializeField]
    private StageEnterTextState currentState;

    private void Awake()
    {
        InitStageEnterButton();

        //isButtonClicked = false;
        currentState = StageEnterTextState.BEFORE;
    }

    private void InitStageEnterButton()
    {
        swapTexts.beforeText.enabled = true;
        swapTexts.afterText.enabled = false;

        enterButton.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isStageUnlocked)
            ClickButtonSwap();
    }

    public void EnterStage()
    {
        SceneManager.LoadScene(moveStageName);
    }

    private void ClickButtonSwap()
    {
        if (currentState == StageEnterTextState.BEFORE)
            SetButtonAfter();
        else
            SetButtonBefore();
    }

    private void SetButtonBefore()
    {
        currentState = StageEnterTextState.BEFORE;
        swapTexts.beforeText.enabled = true;
        swapTexts.afterText.enabled = false;
        enterButton.gameObject.SetActive(false);

        // TODO: Button animation add
    }

    private void SetButtonAfter()
    {
        currentState = StageEnterTextState.AFTER;
        swapTexts.beforeText.enabled = false;
        swapTexts.afterText.enabled = true;
        enterButton.gameObject.SetActive(true);

        // TODO: Button animation add
    }
}
