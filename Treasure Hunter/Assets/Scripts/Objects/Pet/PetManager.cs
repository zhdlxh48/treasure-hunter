using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum PetRate
{
    A = 0, B, C
}

public enum PetState
{
    MOVE, BOMB
}

[System.Serializable]
public struct PetSetting
{
    public PetRate rate;
    public float manaUsage;
    public float attackDamage;
}

public class PetManager : MonoBehaviour
{
    #region Variables

    private Dictionary<PetState, PetFSMState> petStates;

    public PetSetting petSetting;

    public Vector3 moveDirection;
    public float moveSpeed;

    #endregion

    #region Components

    [HideInInspector]
    public Animator petAnimator;
    public SpriteRenderer petSprite;

    #endregion

    #region Event Functions

    private void Awake()
    {
        petAnimator = GetComponentInChildren<Animator>();
        petSprite = GetComponentInChildren<SpriteRenderer>();

        InitStates();
    }

    // Excuted if side collider collided with Enemy or another
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetState(PetState.BOMB);
    }

    #endregion

    #region Action Functions

    // When recall this pet, MOVE and BOMB scripts are disabled
    private void InitStates()
    {
        petStates = new Dictionary<PetState, PetFSMState>();

        petStates[PetState.MOVE] = GetComponent<PetMOVE>();
        petStates[PetState.BOMB] = GetComponent<PetBOMB>();

        foreach (var item in petStates)
        {
            item.Value.enabled = false;
        }
    }

    public void SetState(PetState tempState)
    {
        foreach (var item in petStates)
        {
            item.Value.enabled = false;
        }

        petStates[tempState].enabled = true;
    }

    public void DestroyPet()
    {
        Destroy(gameObject);
    }

    #endregion
}
