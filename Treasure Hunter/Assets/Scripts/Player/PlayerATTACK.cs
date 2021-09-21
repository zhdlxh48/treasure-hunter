using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#pragma warning disable CS0649

public enum PlayerAttackState
{
    GENERAL = 0, RECALL
}

[System.Serializable]
public struct PlayerAttackSetting
{
    public PlayerAttackState attackState;
    public float attackDamage;
    public float manaUsage;
    public float attackRange;
    public float attackDelay;
    public bool isAttackable;
}

public class PlayerAttack : MonoBehaviour
{
    #region Variables

    public PlayerAttackSetting generalAttack;
    public PlayerAttackSetting recallAttack;

    [Range(0, 2)]
    public int targetPet;
    public GameObject[] pets;

    #endregion

    #region Components

    private PlayerManager manager;

    #endregion

    #region Event Functions

    private void Awake()
    {
        generalAttack.isAttackable = true;
        recallAttack.isAttackable = true;

        manager = FindObjectOfType<PlayerManager>();
    }

    #endregion

    #region Attack Functions

    private void InitAttack()
    {
        generalAttack.isAttackable = true;
        recallAttack.isAttackable = true;
    }

    // Animation Delay Functions

    public IEnumerator DelayGeneralAttack()
    {
        if (generalAttack.isAttackable)
        {
            if (manager.SpendMana(generalAttack.manaUsage))
            {
                // General attack disable to do apply attack delay
                generalAttack.isAttackable = false;

                // player animation play
                manager.playerAnimator.SetTrigger("General Attack");

                Debug.Log("General Attacked");

                // apply attack delay
                yield return new WaitForSeconds(generalAttack.attackDelay);

                // enable attack
                generalAttack.isAttackable = true;
            }
        }

        yield break;
    }

    public IEnumerator DelayRecallAttack()
    {
        if (recallAttack.isAttackable)
        {
            if (manager.SpendMana(recallAttack.manaUsage))
            {
                recallAttack.isAttackable = false;

                manager.playerAnimator.SetTrigger("Recall Attack");

                Debug.Log("Recall Attacked");

                yield return new WaitForSeconds(recallAttack.attackDelay);

                recallAttack.isAttackable = true;
            }
        }

        yield break;
    }

    // Inserted on animation by "Animation Event"
    public void DamageThroughGeneralAttack()
    {
        Collider2D[] enemyDetect = Physics2D.OverlapBoxAll(transform.position + new Vector3(0.5f + PlayerController.faceDirection.x * generalAttack.attackRange / 2, 1.5f), new Vector2(generalAttack.attackRange, 1.5f), 0.0f);
        //Collider2D[] enemyDetect = Physics2D.OverlapCircleAll(new Vector2(generalAttack.attackRange, transform.position.y + 1.5f), generalAttack.attackRange);

        int detectEnemyNum = 0;

        foreach (var enemy in enemyDetect)
        {
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                detectEnemyNum++;

                //if (enemy.gameObject.GetComponent<EnemyManager>().enemyHP.currentHP > 0)
                //{
                    enemy.transform.root.SendMessage("ApplyDamage", generalAttack.attackDamage);
                //}  
            }
        }

        Debug.Log("Detect Enemy : " + detectEnemyNum);
    }

    // Inserted on animation by "Animation Event"
    public void RecallPet()
    {
        GameObject pet;

        targetPet = Random.Range(0, 3);

        // SummonPet's rotation is equal with player's rotation (Player's move direction)
        if (PlayerController.faceDirection == Vector3.left)
        {
            pet = Instantiate(pets[targetPet], transform.position + new Vector3(-1.5f, 0.0f), transform.rotation);
            pet.GetComponent<PetManager>().moveDirection = Vector3.left;
            pet.GetComponent<PetManager>().petSprite.flipX = true;
        }
        else
        {
            pet = Instantiate(pets[targetPet], transform.position + new Vector3(1.5f, 0.0f), transform.rotation);
            pet.GetComponent<PetManager>().moveDirection = Vector3.right;
            pet.GetComponent<PetManager>().petSprite.flipX = false;
        }
    }

    #endregion
}