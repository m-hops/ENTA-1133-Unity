using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIHUD : MonoBehaviour
{

    public ArcadeUIStateMachine ArcadeUIStateMachine;
    public TMPro.TMP_Text EnemyName;
    public TMPro.TMP_Text EnemyHP;
    public TMPro.TMP_Text PlayerVesselName;
    public TMPro.TMP_Text PlayerVesselHP;
    public TMPro.TMP_Text CombatTextOutput;
    public TMPro.TMP_Text WeaponSlot0;
    public TMPro.TMP_Text WeaponSlot1;
    public TMPro.TMP_Text WeaponSlot2;
    public TMPro.TMP_Text WeaponSlot3;
    public GameManager GM;
    public CombatEvent CurrentCombatEvent;

    public void SetupCombatEventUI (CombatEvent combatEvent)
    {
        CurrentCombatEvent = combatEvent;
        ArcadeUIStateMachine.CombatScreen();
        CombatTextOutput.text = "[BEGIN COMBAT]";
        UpdateEnemyName(combatEvent.EnemyVessel.Name);
        UpdateEnemyHealth(combatEvent.EnemyVessel.Health);
        UpdatePlayerName(GM.Player.Vessel.Name);
        UpdatePlayerHealth(GM.Player.Vessel.Health);
        WeaponSlot0.text = GM.Player.Vessel.Weapons[0].Name.ToString();
        WeaponSlot1.text = GM.Player.Vessel.Weapons[1].Name.ToString();
        WeaponSlot2.text = GM.Player.Vessel.Weapons[2].Name.ToString();
        WeaponSlot3.text = GM.Player.Vessel.Weapons[3].Name.ToString();
    }

    public void UpdateEnemyName (string name)
    {
        EnemyName.text = name;
    }
    public void UpdateEnemyHealth(int health)
    {
        EnemyHP.text = "HP: " + health.ToString();
    }
    public void UpdatePlayerName(string name)
    {
        PlayerVesselName.text = name;
    }
    public void UpdatePlayerHealth(int health)
    {
        PlayerVesselHP.text = "HP: " + GM.Player.Vessel.Health.ToString();
    }
    public void UpdateCombatText(string txt)
    {
        CombatTextOutput.text = CombatTextOutput.text + "\n\n" + txt;
    }
    public void ClearCombatText()
    {
        CombatTextOutput.text = null;
    }
    public void SelectWeapon(int weaponIndex)
    {
        Debug.Log("SelectWeapon " + weaponIndex);
        CurrentCombatEvent.CombatRoundStage2(GM, weaponIndex);
    }
    public void ShowCombatRound(Vessel player, Vessel enemy)
    {
        CombatTextOutput.text = "[BEGIN COMBAT]";
        UpdateEnemyName(enemy.Name);
        UpdateEnemyHealth(enemy.Health);
        UpdatePlayerName(player.Name);
        UpdatePlayerHealth(player.Health);
        WeaponSlot0.text = player.Weapons[0].Name.ToString();
        WeaponSlot1.text = player.Weapons[1].Name.ToString();
        WeaponSlot2.text = player.Weapons[2].Name.ToString();
        WeaponSlot3.text = player.Weapons[3].Name.ToString();
    }


}
