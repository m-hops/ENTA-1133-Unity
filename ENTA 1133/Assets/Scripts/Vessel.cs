using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    public string Name;
    public int Health;
    public Sprite Sprite;
    public List<Weapon> DefaultWeaponLoadout = new List<Weapon>();
}
