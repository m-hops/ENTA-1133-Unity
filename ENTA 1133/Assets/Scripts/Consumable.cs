using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int PowerLevel;

    public Consumable(string name, int powerLevel, string description, Sprite sprite)
        : base(ItemType.Consumable, name, description, sprite)
    {
        PowerLevel = powerLevel;
    }

}
