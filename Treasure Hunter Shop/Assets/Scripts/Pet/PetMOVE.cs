using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMOVE : PetState
{
    //float waitTime = 0.6f;
    
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(manager.moveDirection * manager.petData.moveSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        manager.petAnimator.SetInteger("PetState", 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 13 - Pet_Wall, 10 - Enemy

        if (collision.gameObject.layer == 13)
        {
            manager.SetState(PetStatus.ATTACK);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            manager.detectEnemy = collision.gameObject;
            manager.SetState(PetStatus.ATTACK);
        }
    }
}
