using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemInfo : MonoBehaviour
{
    public EquipItemType itemType;

    public Sprite itemImage;

    [TextArea(1, 2)]
    public string itemName;
    [TextArea(2, 4)]
    public string itemDesc;
}
