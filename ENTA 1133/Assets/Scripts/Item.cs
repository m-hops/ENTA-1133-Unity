using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Consumable,
        Passive,
        Weapon
    }
    public ItemType Type;
    public string Name;
    public string Description;
    public Sprite Sprite;

    public Item(ItemType type, string name, string description, Sprite sprite)
    {
        Type = type;
        Name = name;
        Description = description;
        Sprite = sprite;
    }
    public virtual void Consume(GameManager gm)
    {

    }
}

