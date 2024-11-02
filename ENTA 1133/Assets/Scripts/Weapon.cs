using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int PowerLevel;

    public Weapon(string name, int powerLevel)
        :base(ItemType.Weapon, name)
    {
        PowerLevel = powerLevel;
    }
   
}
