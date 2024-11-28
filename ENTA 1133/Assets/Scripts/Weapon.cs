using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int PowerLevel;

    public Weapon(string name, int powerLevel, string description, Sprite sprite)
        :base(ItemType.Weapon, name, description, sprite)
    {
        PowerLevel = powerLevel;
    }
   
}
