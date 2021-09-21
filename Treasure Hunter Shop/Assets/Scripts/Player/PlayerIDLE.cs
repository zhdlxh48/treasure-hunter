using UnityEngine;
using System.Collections;

public class PlayerIDLE : PlayerState
{
    private void OnEnable()
    {
        manager.playerAnimator.SetInteger("SetState", (int)manager.currentState);
    }

    public override void VUpdate()
    {
        base.VUpdate();

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
        else if (manager.moveDirection != Vector3.zero)
        {
            manager.SetState(PlayerStateCase.MOVE);
        }
    }
}
