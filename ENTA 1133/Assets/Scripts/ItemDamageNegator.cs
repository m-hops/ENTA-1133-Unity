using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ItemDamageNegator : Item
    {
        public int NegateAmount;

        public ItemDamageNegator(string name, int negateAmount, string description, Sprite sprite) : base(ItemType.Passive, name, description, sprite)
        {
            NegateAmount = negateAmount;
        }
        public override void Consume(GameManager gm)
        {
            gm.Player.DefenseBonus += NegateAmount;
        }
    }
