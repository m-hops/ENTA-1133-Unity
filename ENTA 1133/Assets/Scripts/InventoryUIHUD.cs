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
    public GameObject[] EntryButtons;
    public Sprite DefaultSprite;

    private float yOffset = 0;
    private float offsetAmount = 25;
    public RectTransform ListTransform;

    public void DisplayInventory()
    {

        for (int i = 0; i < ArcadeUIStateMachine.GM.Player.Inventory.Items.Count; i++)
        {
            EntryNames[i].text = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Name;
            EntryDescriptions[i].text = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Description;
            EntryIcons[i].sprite = ArcadeUIStateMachine.GM.Player.Inventory.Items[i].Sprite;
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

    public void SelectItem(int index)
    {
        Item selectedItem = ArcadeUIStateMachine.GM.Player.Inventory.Items[index];
        selectedItem.Consume(ArcadeUIStateMachine.GM);
        ArcadeUIStateMachine.GM.Player.Inventory.RemoveItem(selectedItem);

        EntryNames[index].text = "--";
        EntryDescriptions[index].text = "--";
        EntryIcons[index].sprite = DefaultSprite;
        HP.text = ArcadeUIStateMachine.GM.Player.Vessel.Health.ToString();

    }

    public void ScrollUp()
    {
        if (yOffset < 175)
        {
            yOffset += offsetAmount;
            UpdateListOffset();
        }

    }

    public void ScrollDown()
    {
        if (yOffset > 0)
        {
            yOffset -= offsetAmount;
            UpdateListOffset();
        }
        
    }

    private void UpdateListOffset()
    {
        ListTransform.localPosition = new Vector3(0, yOffset, 0);
    }
}

