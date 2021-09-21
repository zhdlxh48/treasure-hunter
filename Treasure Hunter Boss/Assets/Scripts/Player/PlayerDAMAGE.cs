using UnityEngine;
using System.Collections;

public class PlayerDAMAGE : PlayerState
{
    private void OnEnable()
    {
        if (manager.isDamageable)
        {
            StartCoroutine(manager.InvincibleState());
            manager.anim.Play("Character_Damage");
            sound.damage.start();
    }
    }

    public override void VUpdate()
    {
        base.VUpdate();
        
        ChangeState();
    }

    public override void ChangeState()
    {
        base.ChangeState();

        if (manager.playerData.playerHP <= 0)
        {
            Debug.Log("쥬ㅜ금");
            manager.SetState(PlayerStateCase.DIE);
        }

        if (manager.isMovable)
        {
            if (manager.moveDirection != Vector3.zero)
            {
                manager.SetState(PlayerStateCase.MOVE);
            }
            else
            {
                manager.SetState(PlayerStateCase.IDLE);
            }
        }
    }
}
