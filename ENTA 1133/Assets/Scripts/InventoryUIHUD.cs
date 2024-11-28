using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIHUD : MonoBehaviour
{
    public ArcadeUIStateMachine ArcadeUIStateMachine;
    public Image VesselIcon;
    public TMPro.TMP_Text VesselName;
    public TMPro.TMP_Text[] WeaponNames;
    public TMPro.TMP_Text[] WeaponPowers;
    public TMPro.TMP_Text HP;
    public TMPro.TMP_Text ATKBonus;
    public TMPro.TMP_Text DEFBonus;
    public TMPro.TMP_Text InventoryCount;

    public Image[] EntryIcon;
    public TMPro.TMP_Text[] EntryName;
    public TMPro.TMP_Text[] EntryDescription;

    public void DisplayInventory()
    {
       
        for (int i = 0; i < ArcadeUIStateMachine.GM.Player.Inventory.Items.Count; i++)
        {
            EntryName[i].text = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Name;
            EntryDescription[i].text = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Description;
            EntryIcon[i].sprite = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Sprite;
        }

        VesselIcon.sprite = ArcadeUIStateMachine.GM.Player.Vessel.Sprite;
        VesselName.text = ArcadeUIStateMachine.GM.Player.Vessel.Name;

        for (int i = 0; i < ArcadeUIStateMachine.GM.Player.Vessel.Weapons.Length; i++)
        {
            WeaponNames[i].text = ArcadeUIStateMachine.GM.Player.Vessel.Weapons[i].Name;
            WeaponPowers[i].text = "1-" + ArcadeUIStateMachine.GM.Player.Vessel.Weapons[i].PowerLevel.ToString();
        }

        HP.text = ArcadeUIStateMachine.GM.Player.Vessel.Health.ToString();
        ATKBonus.text = ArcadeUIStateMachine.GM.Player.AttackBonus.ToString();
        DEFBonus.text = ArcadeUIStateMachine.GM.Player.DefenseBonus.ToString();
        InventoryCount.text = ArcadeUIStateMachine.GM.Player.Inventory.Items.Count.ToString() + "/6";
    }
    public void SelectConsumable(int slot)
    {
        switch (slot)
        {
            
        }
    }
}
