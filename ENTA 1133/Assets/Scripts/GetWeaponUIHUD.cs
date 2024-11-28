using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWeaponUIHUD : MonoBehaviour
{
    public ArcadeUIStateMachine ArcadeUIStateMachine;
    public TMPro.TMP_Text Description;
    public TMPro.TMP_Text WeaponName;
    public Image Icon;
    public TMPro.TMP_Text[] CurrentWeapons;

    public void PopupInfo(Weapon weapon)
    {
        WeaponName.text = weapon.Name;
        Description.text = weapon.Description;
        Icon.sprite = weapon.Sprite;

        for (int i = 0; i < CurrentWeapons.Length; i++)
        {
            CurrentWeapons[i].text = ArcadeUIStateMachine.GM.Player.Vessel.Weapons[i].Name;
        }
    }
}
