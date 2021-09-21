using UnityEngine;
using System.Collections;

public enum ItemType
{
    FLOWER, LEATHER, PIPE, ORE
}

public class ItemManager : MonoBehaviour
{
    private ItemType itemType;

    [SerializeField]
    private Rigidbody2D itemRigid;
    [SerializeField]
    private SpriteRenderer itemSprite;

    [SerializeField]
    private float spawnForce;
    [SerializeField]
    private float transparentSpeed;

    private Coroutine itemSpawn;

    private void Awake()
    {
        itemSprite.color = new Color(itemSprite.color.r, itemSprite.color.r, itemSprite.color.b, 0.0f);
    }

    private void Start()
    {
        itemSpawn = StartCoroutine(ItemSpawn());
    }

    private IEnumerator ItemSpawn()
    {
        itemRigid.AddForce(Vector2.up * spawnForce * 100.0f, ForceMode2D.Force);

        while (itemSprite.color.a <= 1.0f)
        {
            itemSprite.color += new Color(0.0f, 0.0f, 0.0f, 0.01f);

            yield return new WaitForSeconds(0.01f * 1 / transparentSpeed);
        }

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            // TODO: Player get item and save item number

            StopCoroutine(itemSpawn);
            Destroy(gameObject);
        }
    }
}
