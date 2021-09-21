using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    [Header("Adjustable Variables")]
    public static Vector3 faceDirection;
    public float moveSpeed;
    public float jumpForce;
    public float additiveJumpTime;

    //[HideInInspector]
    public float moveInput = 0.0f;
    //[HideInInspector]
    public bool jumpInput = false;

    [Header("JumpCheck Variables")]
    public float touchRadius;
    public LayerMask footTouchLayer;
    public LayerMask headTouchLayer;
    
    public bool isControllable = true;
    //[HideInInspector]
    public bool isGrounded = false;
    //[HideInInspector]
    public bool isJumping = true;
    //[HideInInspector]
    public float jumpTimer = 0.0f;
    public float jumpCalibrate;

    #endregion

    #region Components

    [Header("Components")]
    public Transform playerTransform;
    public Transform touchTransform;
    public Rigidbody2D playerRigid;
    public SpriteRenderer playerSprite;

    private PlayerManager manager;

    #endregion

    #region Event Functions

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
        faceDirection = Vector3.right;
    }

    private void FixedUpdate()
    {
        Move(moveInput);
    }

    private void Update()
    {
        Jump(jumpInput);

        CheckGround();
        CheckUpperWall();
        DirectionChange(moveInput);
    }

    #endregion

    #region Action Functions

    public void Move(float moveInput)
    {
        if (!isControllable)
        {
            moveInput = 0.0f;
        }

        // Movement with velocity
        playerRigid.velocity = new Vector2(moveInput * moveSpeed, playerRigid.velocity.y);

        // Animation
        if (playerRigid.velocity == Vector2.zero)
        {
            manager.playerAnimator.SetInteger("Player State", (int)PlayerState.IDLE);
        }
        else
        {
            manager.playerAnimator.SetInteger("Player State", (int)PlayerState.MOVE);
        }
    }
    public void Jump(bool jumpInput)
    {
        if (jumpInput && isControllable)
        {
            if (isGrounded)
            {
                isJumping = true;
                jumpTimer = additiveJumpTime;
                playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //playerRigid.velocity = Vector2.up * jumpForce;
            }
            if (isJumping)
            {
                if (jumpTimer > 0.0f)
                {
                    playerRigid.velocity = Vector2.up * jumpForce;
                    jumpTimer -= Time.deltaTime;
                }
                else isJumping = false;
            }
        }
        else isJumping = false;

        // Animation
        if (playerRigid.velocity.y > jumpCalibrate)
        {
            manager.playerAnimator.SetInteger("Player State", (int)PlayerState.JUMP);
            manager.playerAnimator.SetBool("Falling", false);
        }
        else if (playerRigid.velocity.y < 0.0f)
        {
            manager.playerAnimator.SetBool("Falling", true);
        }
        else
        {
            manager.playerAnimator.SetBool("Falling", false);
        }
    }

    public void CheckGround()
    {
        // Check whether player collided with jumpCheckLayer or not (Applied when player is falling)
        if (playerRigid.velocity.y <= -jumpCalibrate)
        {
            isGrounded = Physics2D.OverlapCircle(touchTransform.position, touchRadius, footTouchLayer);
        }
        //else if (-jumpCalibrate <= playerRigid.velocity.y && playerRigid.velocity.y <= jumpCalibrate)
        //{
        //    if (!isJumping)
        //    {
        //        isGrounded = true;
        //    }
        //}
        else
            isGrounded = false;
        //isGrounded = playerRigid.velocity.y <= 0.0f ? Physics2D.OverlapCircle(touchTransform.position, touchRadius, touchLayer) : false;
    }

    public void CheckUpperWall()
    {
        //if (playerRigid.velocity.y > 0.0f)
        //{
        //    isJumping = Physics2D.OverlapCircle(touchTransform.position + new Vector3(2.5f, 0.0f), touchRadius, footTouchLayer);
        //}
    }

    public void DirectionChange(float moveInput)
    {
        //if (isControllable)
        //{
        //    // Input reversed SpriteRenderer's flipX to flipX  
        //    if (moveInput < 0) playerTransform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        //    else if (0 < moveInput) playerTransform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //}

        if (isControllable)
        {
            if (moveInput < 0)
            {
                playerSprite.flipX = true;
                faceDirection = Vector3.left;
            }
            else if (moveInput > 0)
            {
                playerSprite.flipX = false;
                faceDirection = Vector3.right;
            }
        }
    }

    #endregion
}
