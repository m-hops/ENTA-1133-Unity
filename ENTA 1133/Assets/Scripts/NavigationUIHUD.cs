using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationUIHUD : MonoBehaviour
{
    public ArcadeUIStateMachine ArcadeUIStateMachine;
    public GameManager GM;
    public TMPro.TMP_Text RoomName;
    public TMPro.TMP_Text PlayerVesselName;
    public Image PlayerVesselSprite;
    public TMPro.TMP_Text[] WeaponNames;
    public TMPro.TMP_Text[] WeaponPowers;

    public void Update()
    {
        RoomName.text = GM.CurrentPlayerRoom.Name;
        PlayerVesselName.text = GM.Player.Vessel.Name;
        PlayerVesselSprite.sprite = GM.Player.Vessel.Sprite;
        
        for (int i = 0; i < GM.Player.Vessel.Weapons.Length; i++)
        {
            WeaponNames[i].text = GM.Player.Vessel.Weapons[i].Name;
            WeaponPowers[i].text = "1-" + GM.Player.Vessel.Weapons[i].PowerLevel.ToString();
        }
        

    }

    public void DecryptRoom()
    {
        Debug.Log("Decrypt Room");
        GM.CurrentPlayerRoom.OnDecript(GM);
    }

}
