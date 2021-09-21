using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetATTACK : PetState
{
    private void OnEnable()
    {
        manager.petAnimator.SetInteger("PetState", 2);
    }

    public void Attack()
    {
        if (manager.detectEnemy != null)
        {
            manager.detectEnemy.transform.root.SendMessage("ApplyDamage", manager.petData.attackDamage);
        }
    }

    public void DestroyPet()
    {
        Destroy(gameObject);
    }
}
