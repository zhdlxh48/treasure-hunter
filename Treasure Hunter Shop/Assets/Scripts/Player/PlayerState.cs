using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour
{
    protected PlayerManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    public virtual void ChangeState() { }

    // virtual function, It will be played in the manager class
    public virtual void VFixedUpdate() { }
    public virtual void VUpdate() { }
}
