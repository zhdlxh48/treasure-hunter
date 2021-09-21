using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPlay : MonoBehaviour
{
    public DialogControllManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogControllManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player_Body")
        {
            manager.scene.allowSceneActivation = true;
            Destroy(gameObject);
        }
    }
}
