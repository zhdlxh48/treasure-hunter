using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    protected Rigidbody2D itemRigid;
    protected SpriteRenderer itemSprite;

    protected PlayerManager manager;

    public float spawnForce;
    public float transparentSpeed;

    protected virtual void Awake()
    {
        itemRigid = GetComponent<Rigidbody2D>();
        itemSprite = GetComponentInChildren<SpriteRenderer>();

        manager = FindObjectOfType<PlayerManager>();
    }

    public virtual IEnumerator ItemSpawn() { yield return null; }
    public virtual void GiveItem() { }
}