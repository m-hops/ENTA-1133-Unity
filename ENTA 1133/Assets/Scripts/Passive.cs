using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : Item
{
    public int PowerLevel;

    public Passive(string name, int powerLevel)
        : base(ItemType.Passive, name)
    {
        PowerLevel = powerLevel;
    }
}
