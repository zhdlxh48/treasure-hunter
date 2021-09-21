using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeScene : MonoBehaviour
{
    public string startScene;

    private void Start()
    {
        SceneManager.LoadScene(startScene);
    }
}