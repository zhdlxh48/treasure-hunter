using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogControllManager : MonoBehaviour
{
    public int key = 0;
    public AsyncOperation scene;
    
    void Start ()
    {
        scene = SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
    }
}
