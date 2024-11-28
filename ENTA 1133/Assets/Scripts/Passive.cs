using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : Item
{
    public int PowerLevel;

    public Passive(string name, int powerLevel, string description, Sprite sprite)
        : base(ItemType.Passive, name, description, sprite)
    {
        PowerLevel = powerLevel;
    }
}
