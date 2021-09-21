using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCEvent : MonoBehaviour
{
    public int startIndex;
    private bool isTriggered = false;

    private DialogueManager manager;

    public Image fadeOutImage;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<DialogueManager>();

        fadeOutImage.enabled = false;
    }

    private void Update()
    {
        if (IsClickedFind())
        {
            TriggerActivate();
        }

        if (manager.isJerryEnd)
        {
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeOut()
    {
        fadeOutImage.enabled = true;

        while (fadeOutImage.color.a < 0.98f)
        {
            fadeOutImage.color = Color.Lerp(fadeOutImage.color, Color.black, Time.deltaTime * 0.1f);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("MainScene");
    }

    public void TriggerActivate()
    {
        if (!isTriggered)
        {
            manager.StartDialogue(startIndex);

            isTriggered = true;
        }
    }

    private bool IsClickedFind()
    {
        RaycastHit2D[] hitInfo;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hitInfo = Physics2D.RaycastAll(ray.origin, ray.direction, 100.0f);

        foreach (var item in hitInfo)
        {
            if (item.transform.gameObject.name == "UI_touch")
            {
                return true;
            }
        }

        return false;
    }
}
