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

    //ITEM TYPES//
    public class ItemRepairHP : Item
    {
        int RollLimit;
        public ItemRepairHP(string name, int rollLimit, string description, Sprite sprite) : base(ItemType.Consumable, name, description, sprite)
        {
            RollLimit = rollLimit;
        }
        public override void Consume(GameManager gm)
        {
            int diceRoll = gm.Dice.Roll(RollLimit);
            gm.Player.Vessel.Health += diceRoll;

            Debug.Log("You gained back some health " + diceRoll);
        }
    }
    public class ItemDamageNegator : Item
    {
        int NegateAmount;

        public ItemDamageNegator(string name, int negateAmount, string description, Sprite sprite) : base(ItemType.Passive, name, description, sprite)
        {
            NegateAmount = negateAmount;
        }
        public override void Consume(GameManager gm)
        {
            gm.Player.DefenseBonus += NegateAmount;
        }
    }
    public class ItemDamageEnhance : Item
    {
        int AddAmount;

        public ItemDamageEnhance(string name, int addAmount, string description, Sprite sprite) : base(ItemType.Passive, name, description, sprite)
        {
            AddAmount = addAmount;
        }
        public override void Consume(GameManager gm)
        {
            gm.Player.AttackBonus += AddAmount;
        }
    }
}

