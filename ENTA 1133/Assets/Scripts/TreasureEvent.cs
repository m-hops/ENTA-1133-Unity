using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureEvent : Event
{
    public override void Execute(GameManager gm)
    {
        int roomSelection = gm.Dice.Roll(3);
        List<Weapon> weaponPool = gm.TreasurePoolWeapons;
        List<Item> consumablePool = gm.TreasurePoolConsumable;
        List<Item> passivePool = gm.TreasurePoolPassive;
        Item selectedItem;

        switch (roomSelection)
        {
            case 1:
                {
                    int poolSize = weaponPool.Count;
                    int selectedIndex = gm.Dice.Roll(poolSize) - 1;
                    Weapon weapon = weaponPool[selectedIndex];
                    weaponPool.RemoveAt(selectedIndex);
                    TreasureWeapon(gm, weapon);
                }
                break;
            case 2:
                {
                    int poolSize = consumablePool.Count;
                    int selectedIndex = gm.Dice.Roll(poolSize) - 1;
                    selectedItem = consumablePool[selectedIndex];
                    consumablePool.RemoveAt(selectedIndex);
                    TreasureItem(gm, selectedItem);
                }
                break;
            case 3:
                {
                    int poolSize = passivePool.Count;
                    int selectedIndex = gm.Dice.Roll(poolSize) - 1;
                    selectedItem = passivePool[selectedIndex];
                    passivePool.RemoveAt(selectedIndex);
                    TreasureItem(gm, selectedItem);
                    selectedItem.Consume(gm);
                }
                break;
        }

        IsDecrypted = true;
    }

    public void TreasureWeapon(GameManager gm, Weapon weapon)
    {
        Debug.Log("Player Gains a weapon");
    }

    public void TreasureItem(GameManager gm, Item item)
    {
        gm.Player.Inventory.AddItem(item);
        Debug.Log("Player Gains an item");
    }
}
