using UnityEngine;
using System.Collections;

#pragma warning disable CS0649

public enum LootType
{
    FLOWER = 0, LEATHER, MARBLE, SLATE
}

public class LootManager : DropItem
{
    public LootType lootType;
    public int lootCount;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
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

    public override void GiveItem()
    {
        manager.GetLootTemp(lootType, lootCount);
    }
}
