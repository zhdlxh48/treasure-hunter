using System;
using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public int startIndex;
    private bool isTriggered = false;

    private DialogueManager manager;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<DialogueManager>();
    }

    public void TriggerActivate()
    {
        manager.StartDialogue(startIndex);

        isTriggered = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                TriggerActivate();
            }
        }
    }
}
