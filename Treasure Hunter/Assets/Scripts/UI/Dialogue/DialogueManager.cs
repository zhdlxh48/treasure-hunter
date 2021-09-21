using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class DialogueCommand
{
    public static int NON_IMAGE = -1;
    public static string NARRATION = "<EMPTY_NAME>";
    public static string END_DIALOGUE = "<EXIT>";
}

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;
    
    public int startIndexPos;

    // Dialogue object (used on show, fade)
    public GameObject dialogueUI;

    // Dialogue back image
    public Image blackBG;
    public Image nameBackImage;
    public ImageChanger faceChanger;
    public ImageChanger backgroundChanger;

    // Display elements
    public Text nameText;
    public Text dialogueText;

    // used on typing effects variables
    private bool isTyping = false;
    public float typingSpeed;

    // 영상을 찍기 위한... 변수들....
    public bool isJerryEnd = false;
    public GameObject missionWindow;

    private void Awake()
    {
        nameText.text = null;
        dialogueText.text = null;
        faceChanger.changeImage.sprite = null;
        backgroundChanger.changeImage.sprite = null;

        missionWindow.SetActive(false);

        dialogueUI.SetActive(false);
    }

    public void StartDialogue(int index)
    {
        startIndexPos = index;

        dialogueUI.SetActive(true);

        PlayDialogue();
    }

    public void PlayDialogue()
    {
        if (!isTyping)
        {
            if (dialogue.dataArray[startIndexPos].Text != DialogueCommand.END_DIALOGUE)
            {
                // Dialogue Set
                StartCoroutine(TypeDialogue(dialogue.dataArray[startIndexPos].Text));

                // blackBG Set
                blackBG.enabled = dialogue.dataArray[startIndexPos].Background == DialogueCommand.NON_IMAGE ? false : true;

                // Face Set
                faceChanger.SetImage(dialogue.dataArray[startIndexPos].Face);
                // BG Set
                backgroundChanger.SetImage(dialogue.dataArray[startIndexPos].Background);
                // Name Set
                if (dialogue.dataArray[startIndexPos].Name != DialogueCommand.NARRATION)
                {
                    nameBackImage.enabled = true;
                    nameText.text = dialogue.dataArray[startIndexPos].Name;
                }
                else
                {
                    nameBackImage.enabled = false;
                    nameText.text = "";
                }

                startIndexPos++;
            }
            else
            {
                Debug.Log("End of dialogue");

                nameText.text = null;
                dialogueText.text = null;
                faceChanger.changeImage.sprite = null;
                faceChanger.changeImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                backgroundChanger.changeImage.sprite = null;
                backgroundChanger.changeImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

                // 영상용... 
                if (startIndexPos == 14)
                {
                    missionWindow.SetActive(true);
                }
                if (startIndexPos == 27)
                {
                    isJerryEnd = true;
                }

                dialogueUI.SetActive(false);
            }
        }
        else
        {
            StopAllCoroutines();

            faceChanger.StopAllCoroutines();
            faceChanger.changeImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            backgroundChanger.StopAllCoroutines();
            backgroundChanger.changeImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            isTyping = false;

            dialogueText.text = dialogue.dataArray[startIndexPos - 1].Text;
        }
    }

    private IEnumerator TypeDialogue(string dialogue)
    {
        isTyping = true;

        dialogueText.text = "";

        foreach (var letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}
