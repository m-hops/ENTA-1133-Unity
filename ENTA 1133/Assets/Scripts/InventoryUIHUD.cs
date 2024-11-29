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

    public Image[] EntryIcons;
    public TMPro.TMP_Text[] EntryNames;
    public TMPro.TMP_Text[] EntryDescriptions;

    //public ScrollRect ConsumableArea;

    public void DisplayInventory()
    {

        //for (int i = 0; i < ArcadeUIStateMachine.GM.Player.Inventory.Items.Count; i++)
        //{
        //    EntryNames[i].text = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Name;
        //    EntryDescriptions[i].text = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Description;
        //    EntryIcons[i].sprite = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Sprite;
        //}

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

    public void SelectItem()
    {
        Debug.Log("Item Selected");
    }

    public void ScrollUp()
    {
        Debug.Log("Scroll Up");
        //ConsumableArea.normalizedPosition = new Vector2(0f, 0.5f);
    }

    public void ScrollDown()
    {
        Debug.Log("Scroll Down");
        //ConsumableArea.verticalNormalizedPosition -= 0.2f;
    }
}

