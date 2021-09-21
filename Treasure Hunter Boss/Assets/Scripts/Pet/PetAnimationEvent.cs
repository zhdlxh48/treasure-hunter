using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private PetState[] states;

    public void ToMove()
    {
        (states[0] as PetCALL).EndAnimation();
    }

    public void Attack()
    {
        (states[1] as PetATTACK).Attack();
    }

    public void Destroy()
    {
        (states[1] as PetATTACK).DestroyPet();
    }
}
