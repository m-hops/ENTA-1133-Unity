using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvent : Event
{
    public int RoundCounter = 0;
    //RUNS MULTIPLE COMBAT ROUNDS UNTIL PLAYER OR ENEMY IS DEAD//
    public override void Execute(GameManager gm)
    {
        Vessel enemyVessel = GameObject.Instantiate(gm.EnemyVesselsPool[0]);
        gm.EnemyVesselsPool.RemoveAt(0);
        enemyVessel.ResetWeapons();
        gm.Player.Vessel.ResetWeapons();

        //RESETS WEAPON POOL EVERY 4 ROUNDS//
        while (!IsEventConcluded)
        {
            CombatRound(gm, enemyVessel);

            RoundCounter++;
            if (RoundCounter % Vessel.kWeaponCount == 0)
            {
                gm.Player.Vessel.ResetWeapons();
                enemyVessel.ResetWeapons();
            }
        }

        IsDecrypted = true;
        if (gm.EnemyVesselsPool.Count == 0)
        {
            Win(gm);
        }
    }
    //BEHAVIOUR FOR A SINGLE ROUND OF COMBAT//
    public void CombatRound(GameManager gm, Vessel enemyVessel)
    {
        string dialogUpdate = gm.CombatUIHUD.CombatDialog;
        int playerVesselWeaponIndex = -1;

        while (playerVesselWeaponIndex < 0)
        {
            //RUNS THROUGH ARRAY AND LIST TO RETURN STILL VALID WEAPONS OR QUEUE WEAPON RESET//
            for (int i = 0; i < gm.Player.Vessel.WeaponsReady.Count; i++)
            {
                int weaponIndex = gm.Player.Vessel.WeaponsReady[i];
                Debug.Log(gm.Player.Vessel.Weapons[weaponIndex].Name);
                //TEMPORARY; SIMULATE PLAYER SELECTING THE LAST AVAILABLE WEAPON INDEX//
                playerVesselWeaponIndex = i;
            }
        }

        int enemyVesselWeaponIndex = enemyVessel.GetRandomAvailableWeaponIndex(gm.Dice);
        string enemyVesselCurrentWeapon = enemyVessel.Weapons[enemyVesselWeaponIndex].Name;
        string playerVesselCurrentWeapon = gm.Player.Vessel.Weapons[playerVesselWeaponIndex].Name;
        int playerVesselDice = gm.Player.Vessel.Weapons[playerVesselWeaponIndex].PowerLevel;
        int enemyVesselDice = enemyVessel.Weapons[playerVesselWeaponIndex].PowerLevel;
        int playerVesselRollResult = gm.Dice.Roll(playerVesselDice);
        int enemyVesselRollResult = gm.Dice.Roll(enemyVesselDice);
        int playerVesselAttackBonus = gm.Player.AttackBonus;
        int playerVesselDefenseBonus = gm.Player.DefenseBonus;

        playerVesselRollResult += playerVesselAttackBonus;

        if (playerVesselRollResult > enemyVesselRollResult)
        {
            int dmg = playerVesselRollResult - enemyVesselRollResult;
            enemyVessel.Health -= dmg;
            dialogUpdate = "Enemy takes " + dmg + ".";
            dialogUpdate = "Enemy vessel is now at " + enemyVessel.Health + " HP.";

        } else if (playerVesselRollResult < enemyVesselRollResult)
        {
            int dmg = enemyVesselRollResult - playerVesselRollResult;
            dmg -= playerVesselDefenseBonus;

            if (dmg > 0)
            {
                gm.Player.Vessel.Health -= dmg;
                dialogUpdate = "Player takes " + dmg + ".";
                dialogUpdate = "Player vessel is now at " + gm.Player.Vessel.Health + " HP.";
            } else
            {
                dialogUpdate = "Player negates all damage with defense bonus";
            }
            
        } else
        {
            dialogUpdate = "Same roll; action cancelled out.";
        }

        if (gm.Player.Vessel.Health <= 0)
        {
            dialogUpdate = "Player was killed by the enemy";
            gm.IsPlayerAlive = false;
            IsEventConcluded = true;
            dialogUpdate = "Lose event happens here";
        }

        if (enemyVessel.Health <= 0)
        {
            dialogUpdate = "Enemy was killed by the player";
            IsEventConcluded = true;
            dialogUpdate = "Win event happens here";
        }
    }

    public void Lose(GameManager gm)
    {
        gm.IsGameRunning = false;
    }

    public void Win(GameManager gm)
    {
        gm.IsGameRunning = false;
    }

}
