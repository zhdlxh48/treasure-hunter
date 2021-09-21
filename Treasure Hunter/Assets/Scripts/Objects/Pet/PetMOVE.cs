using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMOVE : PetFSMState
{
    #region Event Functions

    private void Update()
    {
        Move();
    }

    #endregion

    #region Action Functions

    private void Move()
    {
        transform.Translate(manager.moveSpeed * manager.moveDirection * Time.deltaTime);
    }

    #endregion
}
