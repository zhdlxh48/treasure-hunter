using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOVE : PlayerState
{
    private void OnEnable()
    {
        manager.playerAnimator.SetInteger("SetState", (int)manager.currentState);
    }

    public override void VFixedUpdate()
    {
        base.VFixedUpdate();

        ActionUtil.Move(manager.moveObject, manager.moveDirection, manager.playerData.moveSpeed, manager.isMovable);
    }

    public override void VUpdate()
    {
        base.VUpdate();

        SightDirection();
        ChangeState();
    }

    public override void ChangeState()
    {
        base.ChangeState();

        if (manager.attackState != PlayerAttackCase.NOTHING)
        {
            if (manager.isAttackable)
            {
                manager.SetState(PlayerStateCase.ATTACK);
            }
        }
        else if (manager.moveDirection == Vector3.zero)
        {
            manager.SetState(PlayerStateCase.IDLE);
        }
    }

    // Rotate the sprite in the direction the character moves
    private void SightDirection()
    {
        if (manager.moveDirection == Vector3.left) manager.playerSprite.flipX = true;
        else if (manager.moveDirection == Vector3.right) manager.playerSprite.flipX = false;
    }
}