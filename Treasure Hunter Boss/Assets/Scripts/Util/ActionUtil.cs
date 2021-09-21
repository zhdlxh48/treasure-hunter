using UnityEngine;

public static class ActionUtil
{
    public static void Move(Transform moveObject, Vector3 moveDirection, float moveSpeed, bool isMovable)
    {
        if (!isMovable) return;

        moveObject.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public static void Jump(Rigidbody2D jumpObject, Vector3 jumpDirection, float jumpPower, ForceMode2D jumpType, bool jumpState)
    {
        jumpObject.AddForce(jumpDirection * jumpPower, jumpType);
        jumpState = true;
    }
}