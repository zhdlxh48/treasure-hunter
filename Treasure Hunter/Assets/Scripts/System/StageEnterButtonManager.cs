using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum AdventureStage
{
    STAGE_1 = 0, STAGE_2, STAGE_3
}

public class StageEnterButtonManager : MonoBehaviour
{
    public AdventureStage enabledStage;

    [SerializeField]
    private GameObject[] contentStages;

    public bool[] isStageUnlocked;

    private ScrollRect scrollRect;

    private Dictionary<AdventureStage, GameObject> stageButtonObjects;

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();

        enabledStage = AdventureStage.STAGE_1;

        stageButtonObjects = new Dictionary<AdventureStage, GameObject>();
        InitStageButtonsObjects();

        SetStage(enabledStage);
    }

    private void InitStageButtonsObjects()
    {
        stageButtonObjects[AdventureStage.STAGE_1] = contentStages[0];
        stageButtonObjects[AdventureStage.STAGE_2] = contentStages[1];
        stageButtonObjects[AdventureStage.STAGE_3] = contentStages[2];
    }

    public void Stage1Click()
    {
        SetStage(AdventureStage.STAGE_1);
    }

    public void Stage2Click()
    {
        SetStage(AdventureStage.STAGE_2);
    }

    public void Stage3Click()
    {
        SetStage(AdventureStage.STAGE_3);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void SetStage(AdventureStage stage)
    {
        if (isStageUnlocked[(int)stage])
        {
            foreach (var item in stageButtonObjects)
            {
                item.Value.SetActive(false);
            }

            stageButtonObjects[stage].SetActive(true);

            scrollRect.content = stageButtonObjects[stage].GetComponent<RectTransform>();

            enabledStage = stage;
        }
    }
}
