using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    protected Rigidbody2D itemRigid;
    protected SpriteRenderer itemSprite;

    public float spawnForce;
    public float transparentSpeed;

    protected virtual void Awake()
    {
        itemRigid = GetComponent<Rigidbody2D>();
        itemSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShoHwan());
    }

    public IEnumerator ShoHwan()
    {
        itemRigid.AddForce(new Vector2(0, spawnForce), ForceMode2D.Impulse);

        float transpert = 0.0f;

        while (transpert <= 1.0f)
        {
            itemSprite.color = new Color(1.0f, 1.0f, 1.0f, transpert);

            transpert += 0.05f;

            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<BossArtifact>().Invoke("ScreenFadeOut", 1.0f);

            Destroy(gameObject);
        }
    }

    //public virtual IEnumerator ItemSpawn() { yield return null; }
    //public virtual void GiveItem() { }
}