using UnityEngine;
using System.Collections;

public class PlayerATTACK : PlayerState
{
//Original function for player's attack has been modified
    private void OnEnable()
    {
        if (manager.playerData.generalAttackDelay <= manager.generalAttackTimer)
        {
            if (manager.attackState == PlayerAttackCase.GENERAL)
            {
                manager.playerAnimator.SetInteger("SetState", (int)manager.currentState);
                manager.playerAnimator.SetInteger("AttackState", (int)manager.attackState);
                /*if (manager.player.IsTouchingLayers(manager.attack2Layer))
                {
                    AttackUtil.BossAttack(transform, manager.playerData.attackRange, manager.playerData.attackDamage, manager.attackState);
                    sound.hit.start();
                }
                else*/
                    AttackUtil.GeneralAttack(transform, manager.playerData.attackRange, manager.playerData.attackDamage, manager.attackState);
                manager.generalAttackTimer = 0.0f;
                sound.attack.start();
            }
        }
        if (manager.playerData.recallAttackDelay <= manager.recallAttackTimer)
        {
            if (manager.attackState == PlayerAttackCase.RECALL)
            {
                Vector3 petMoveDirection = (manager.playerSprite.flipX == false) ? Vector3.right : Vector3.left;

                manager.playerAnimator.SetInteger("SetState", (int)manager.currentState);
                manager.playerAnimator.SetInteger("AttackState", (int)manager.attackState);
                AttackUtil.RecallAttack(transform, manager.playerSprite.flipX, manager.petObject[(int)manager.petClass], manager.petClass, petMoveDirection, manager.attackState);
                manager.recallAttackTimer = 0.0f;
            }
        }


        /////////////////
        
        //sound.hit.start();
    }

    public override void VUpdate()
    {
        base.VUpdate();

        ChangeState();
    }

    public override void ChangeState()
    {
        base.ChangeState();

        if (manager.moveDirection == Vector3.zero)
        {
            manager.SetState(PlayerStateCase.IDLE);
        }
        else if (manager.moveDirection != Vector3.zero)
        {
            manager.SetState(PlayerStateCase.MOVE);
        }
    }

}
