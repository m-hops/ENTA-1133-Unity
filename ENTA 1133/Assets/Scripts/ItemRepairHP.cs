using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ItemRepairHP : Item
    {
        public int RollLimit;

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