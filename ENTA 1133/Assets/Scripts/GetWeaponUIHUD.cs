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
    private Weapon selectedWeapon;

    public void PopupInfo(Weapon weapon)
    {
        selectedWeapon = weapon;
        WeaponName.text = weapon.Name;
        Description.text = weapon.Description;
        Icon.sprite = weapon.Sprite;

        for (int i = 0; i < CurrentWeapons.Length; i++)
        {
            CurrentWeapons[i].text = ArcadeUIStateMachine.GM.Player.Vessel.Weapons[i].Name;
        }
    }

    public void SelectOption(int weaponIndex)
    {
        switch (weaponIndex)
        {
            case 0:
                ArcadeUIStateMachine.GM.Player.Vessel.SetWeapon(selectedWeapon, 0);
                ArcadeUIStateMachine.CloseGetWeapon();
                break;
            case 1:
                ArcadeUIStateMachine.GM.Player.Vessel.SetWeapon(selectedWeapon, 1);
                ArcadeUIStateMachine.CloseGetWeapon();
                break;
            case 2:
                ArcadeUIStateMachine.GM.Player.Vessel.SetWeapon(selectedWeapon, 2);
                ArcadeUIStateMachine.CloseGetWeapon();
                break;
            case 3:
                ArcadeUIStateMachine.GM.Player.Vessel.SetWeapon(selectedWeapon, 3);
                ArcadeUIStateMachine.CloseGetWeapon();
                break;
            default:
                break;
        }
    }
}
