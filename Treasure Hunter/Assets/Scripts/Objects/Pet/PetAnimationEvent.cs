using UnityEngine;
using System.Collections;

public class PetAnimationEvent : MonoBehaviour
{
    private PetManager manager;
    private PetBOMB bomb;

    private void Awake()
    {
        manager = GetComponentInParent<PetManager>();
        bomb = GetComponentInParent<PetBOMB>();
    }

    public void AllowMove()
    {
        manager.SetState(PetState.MOVE);
    }

    public void Bomb()
    {
        bomb.BombAttack();
    }

    public void DestroyPet()
    {
        manager.DestroyPet();
    }
}
