using UnityEngine;
using System.Collections;

public class MovementButtonManager : MonoBehaviour
{
    #region Variables

    private PlayerController controller;

    #endregion

    #region Event Functions

    private void Awake()
    {
        controller = GameObject.FindObjectOfType<PlayerController>();
    }

    #endregion

    #region Action Functions

    public void JumpButtonDown()
    {
        controller.jumpInput = true;
    }
    public void JumpButtonUp()
    {
        controller.jumpInput = false;
    }

    public void RightButtonDown()
    {
        controller.moveInput = 1.0f;
    }
    public void RightButtonUp()
    {
        controller.moveInput = 0.0f;
    }

    public void LeftButtonDown()
    {
        controller.moveInput = -1.0f;
    }
    public void LeftButtonUp()
    {
        controller.moveInput = 0.0f;
    }

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //OnJumpButton?.Invoke(true);
            controller.jumpInput = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //OnJumpButton?.Invoke(false);
            controller.jumpInput = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //OnMoveButton?.Invoke(-1.0f);
            controller.moveInput = -1.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //OnMoveButton?.Invoke(0.0f);
            controller.moveInput = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //OnMoveButton?.Invoke(1.0f);
            controller.moveInput = 1.0f;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //OnMoveButton?.Invoke(0.0f);
            controller.moveInput = 0.0f;
        }
    }
}
