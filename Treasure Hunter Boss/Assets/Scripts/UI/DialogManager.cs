using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public GameObject root;

    public ExcelSheet dialogSheet;

    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Image faceImage;

    private ExcelSheetData[] dialogData;
    public Sprite[] faceBundle;
    
    [SerializeField]
    private int key;

    private bool isTyping;

    private Coroutine typingTask;

    private void Awake()
    {
        key = -1;
        isTyping = false;
        dialogData = dialogSheet.dataArray;
    }

    private void Start()
    {
        ClickDialog();
    }

    private IEnumerator TypingText()
    {
        isTyping = true;

        string sentence = dialogData[key].Text;

        foreach (var item in sentence)
        {
            if (isTyping) dialogText.text += item;
            yield return new WaitForSeconds(0.08f);
        }

        isTyping = false;
    }

    public void ClickDialog()
    {
        // When Users click the screen, while each letter is displayed one by one,
        // you can see all the letters immediately
        if (isTyping)
        {
            if (key != 0) StopCoroutine(typingTask);

            // Erase remaining characters
            dialogText.text = "";
            // Show dialog text 'immediately'
            dialogText.text = dialogData[key - 1].Text;
            // Do not allow typing in coroutine - "TypingText"
            isTyping = false;

            return;
        }

        // This is function which is appear the next sentence to dialog screen
        // Make sure the next text(key + 1) is an ending string
        if (dialogData[key + 1].Text != "<EXIT>")
        {
            // Go to next key value
            // at the first of start this function, this make key value to 0 (initiallize)
            ++key;

            if (key != 0) StopCoroutine(typingTask);

            // Erase remaining characters
            dialogText.text = "";
            // Show face sprite
            faceImage.sprite = faceBundle[dialogData[key].Face];
            // Show name text
            nameText.text = dialogData[key].Name;
            // Show dialog text
            typingTask = StartCoroutine(TypingText());
        }
        else
        {
            // The printing sentence is over
            Debug.Log("End");
            Destroy(root);
        }
    }
}
