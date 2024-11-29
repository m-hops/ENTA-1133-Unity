using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ItemDamageEnhance : Item
    {
        public int AddAmount;

        public ItemDamageEnhance(string name, int addAmount, string description, Sprite sprite) : base(ItemType.Passive, name, description, sprite)
        {
            AddAmount = addAmount;
        }
        public override void Consume(GameManager gm)
        {
            gm.Player.AttackBonus += AddAmount;
        }
    }

