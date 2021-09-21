using UnityEngine;
using System.Collections;

public class ItemCollector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Categorize with Item class type
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            other.gameObject.GetComponent<DropItem>().GiveItem();

            Destroy(other.gameObject);
        }
    }
}
