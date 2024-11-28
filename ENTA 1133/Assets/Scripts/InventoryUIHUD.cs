using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIHUD : MonoBehaviour
{
    public Image VesselIcon;
    public TMPro.TMP_Text VesselName;
    public TMPro.TMP_Text[] WeaponNames;
    public TMPro.TMP_Text[] WeaponPowers;
    public TMPro.TMP_Text HP;
    public TMPro.TMP_Text ATKBonus;
    public TMPro.TMP_Text DEFBonus;
    public GameObject[] InvEntry;
    public GameManager GM;

    public void Update()
    {
        VesselIcon.sprite = GM.Player.Vessel.Sprite;
        VesselName.text = GM.Player.Vessel.Name;

        for (int i = 0; i < GM.Player.Vessel.Weapons.Length; i++)
        {
            WeaponNames[i].text = GM.Player.Vessel.Weapons[i].Name;
            WeaponPowers[i].text = "1-" + GM.Player.Vessel.Weapons[i].PowerLevel.ToString();
        }

        HP.text = GM.Player.Vessel.Health.ToString();
        ATKBonus.text = GM.Player.AttackBonus.ToString();
        DEFBonus.text = GM.Player.DefenseBonus.ToString();

        for (int i = 0; i < GM.Player.Inventory.Items.Count; i++)
        {
            
        }

    }

}
