using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFSMState : MonoBehaviour
{
    [HideInInspector]
    public PetManager manager;

    private void Awake()
    {
        manager = GetComponent<PetManager>();
    }
}
