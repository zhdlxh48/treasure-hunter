using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : DropItem
{

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(ItemSpawn());
    }

    public override IEnumerator ItemSpawn()
    {
        itemRigid.AddForce(Vector2.up * spawnForce, ForceMode2D.Impulse);

        while (itemSprite.color.a <= 1.0f)
        {
            itemSprite.color += new Color(0.0f, 0.0f, 0.0f, 0.01f);

            yield return new WaitForSeconds(0.01f * 1 / transparentSpeed);
        }

        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!FindObjectOfType<BossManager>().isTouched)
            {
                FindObjectOfType<BossManager>().GoOnShow();

                Destroy(gameObject);
            }
        }
        
    }
}
