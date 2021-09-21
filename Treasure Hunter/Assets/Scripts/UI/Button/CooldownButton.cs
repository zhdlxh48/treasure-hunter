using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownButton : MonoBehaviour
{
    public Button button;
    public Image cooldownImage;
    public Text cooldownText;
    public float cooldownTime;

    public bool isCooldown;

    private void Start()
    {
        SetCooldownState(false);
    }

    private void SetCooldownState(bool setState)
    {
        isCooldown = setState;
        button.interactable = !setState;
        cooldownImage.enabled = setState;
    }

    public void StartCooldown()
    {
        if (!isCooldown)
        {
            Debug.Log("Cooldown Start");

            SetCooldownState(true);
            StartCoroutine(ProgressCooldown());
        }
    }

    private IEnumerator ProgressCooldown()
    {
        Debug.Log("Cooldown Progress");
        while (cooldownImage.fillAmount > 0.0f)
        {
            cooldownImage.fillAmount -= 1 / cooldownTime * Time.deltaTime;
            yield return null;
        }

        Debug.Log("Cooldown End");
        SetCooldownState(false);
        cooldownImage.fillAmount = 1.0f;

        yield break;
    }
}
