using UnityEngine;
using System.Collections;

public class JumpFunction : MonoBehaviour
{
    // Object related to jump
    public Rigidbody2D jumpObject;

    // Settings related to jump
    public Vector3 jumpDirection;
    public float jumpPower;
    public ForceMode2D jumpType;

    // Jump animation component
    public Animator jumpAnimation;

    // Status values ​​related to jump
    private bool isJumping;

    private void Awake()
    {
        isJumping = false;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            ActionUtil.Jump(jumpObject, jumpDirection, jumpPower, jumpType, isJumping);

            jumpAnimation.SetTrigger("Jumping");
        }
    }

    // "IsJumping = false" in the landing state
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Velocity will be checked, To know that whether the velocity change into 0 when collided with Floor or not
        if (jumpObject.velocity.y <= 0)
        {
            if (other.gameObject.layer == 8)
            {
                jumpAnimation.SetBool("Falling", isJumping = false);
            }
        }
    }

    // "isJumping = true" in the air
    private void OnCollisionExit2D(Collision2D other)
    {
        // When exiting from X, check if speed is 0 or more (Exclusive)
        if (jumpObject.velocity.y > 0)
        {
            if (other.gameObject.layer == 8)
            {
                jumpAnimation.SetBool("Falling", isJumping = true);
            }
        }
    }
}
