using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AttackUtil
{
    private static Vector3 distanceAttackStart = new Vector3(0.0f, 0.0f, 0.0f);
    private static float distanceRecallStart = 2.0f;

    public static void GeneralAttack(Transform player, float attackRange, float attackDamage, PlayerAttackCase attackState)
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(player.position + distanceAttackStart, attackRange, Vector2.zero, 0.0f, 1 << 10);

        foreach (var item in hit)
        {
            item.transform.gameObject.GetComponent<EnemyManager>().SendMessage("ApplyDamage", attackDamage);

            attackState = PlayerAttackCase.NOTHING;
        }
    }


    //*******************************
    public static void BossAttack(Transform player, float attackRange, float attackDamage, PlayerAttackCase attackState)
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(player.position + distanceAttackStart, attackRange, Vector2.zero, 0.0f, 1 << 10);

        
            GameObject.FindGameObjectWithTag("BossEnemy").GetComponent<BossManager>().SendMessage("ApplyDamage", attackDamage);

            attackState = PlayerAttackCase.NOTHING;
        
    }
    //*************************


    public static void RecallAttack(Transform player, bool playerFlip, GameObject petObject, PetClass callPet, Vector3 petMoveDirection, PlayerAttackCase attackState)
    {
        GameObject tempPet = Object.Instantiate(petObject, player.position + new Vector3(distanceRecallStart * petMoveDirection.x, -2.0f), player.rotation);

        tempPet.GetComponent<PetManager>().moveDirection = petMoveDirection;
        tempPet.GetComponentInChildren<SpriteRenderer>().flipX = playerFlip;

        attackState = PlayerAttackCase.NOTHING;
    }
}
