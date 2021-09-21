using UnityEngine;
using System.Collections;

public enum WeaponType
{
    MECHANIC_GUN, FIRE_WAND
}

[System.Serializable]
public class WeaponItem : MonoBehaviour
{
    public WeaponType weaponType;
}
