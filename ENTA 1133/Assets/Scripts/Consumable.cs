using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int PowerLevel;

    public Consumable(string name, int powerLevel)
        : base(ItemType.Consumable, name)
    {
        PowerLevel = powerLevel;
    }

}
