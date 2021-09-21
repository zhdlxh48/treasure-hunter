using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class PetState : MonoBehaviour {

    public PetManager manager;

    private void Awake()
    {
        manager = GetComponent<PetManager>();
    }
}
