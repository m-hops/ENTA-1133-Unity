using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIHUD : MonoBehaviour
{
    public TMPro.TMP_Text EnemyInfo;
    public TMPro.TMP_Text PlayerVesselName;
    public TMPro.TMP_Text PlayerVesselHP;
    public TMPro.TMP_Text CombatTextOutput;
    public TMPro.TMP_Text WeaponSlot0;
    public TMPro.TMP_Text WeaponSlot1;
    public TMPro.TMP_Text WeaponSlot2;
    public TMPro.TMP_Text WeaponSlot3;
    public string CombatDialog;
    public GameManager GM;

    public void Update()
    {
        EnemyInfo.text = "This is a test";
        PlayerVesselName.text = GM.Player.Vessel.Name;
        PlayerVesselHP.text = "HP: " + GM.Player.Vessel.Health.ToString();
        CombatTextOutput.text = CombatTextOutput.text + "\n\n" + CombatDialog;
        WeaponSlot0.text = GM.Player.Vessel.Weapons[0].Name.ToString();
        WeaponSlot1.text = GM.Player.Vessel.Weapons[1].Name.ToString();
        WeaponSlot2.text = GM.Player.Vessel.Weapons[2].Name.ToString();
        WeaponSlot3.text = GM.Player.Vessel.Weapons[3].Name.ToString();
    }
}
