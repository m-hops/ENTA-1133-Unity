using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvent : Event
{
    public int RoundCounter = 0;
    public Vessel EnemyVessel;

    //RUNS MULTIPLE COMBAT ROUNDS UNTIL PLAYER OR ENEMY IS DEAD//
    public override void Execute(GameManager gm)
    {
        EnemyVessel = GameObject.Instantiate(gm.EnemyVesselsPool[1], gm.Player.ObjectSpawnArea.transform);
        gm.EnemyVesselsPool.RemoveAt(1);
        EnemyVessel.ResetWeapons();
        gm.Player.Vessel.ResetWeapons();

        gm.CombatUIHUD.SetupCombatEventUI(gm.Player.Vessel, EnemyVessel);

        //RESETS WEAPON POOL EVERY 4 ROUNDS//
        while (!IsEventConcluded)
        {
            CombatRound(gm, EnemyVessel);

            RoundCounter++;
            if (RoundCounter % Vessel.kWeaponCount == 0)
            {
                gm.Player.Vessel.ResetWeapons();
                EnemyVessel.ResetWeapons();
            }
        }

        //SETS ROOM TO TO DECRYPTED AFTER COMBAT;
        IsDecrypted = true;
        if (gm.EnemyVesselsPool.Count == 0)
        {
            Win(gm);
        }
    }
    //BEHAVIOUR FOR A SINGLE ROUND OF COMBAT//
    public void CombatRound(GameManager gm, Vessel enemyVessel)
    {
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

        //SETUP FOR COMBAT CALCULATIONS//
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

        //IF PLAYER ROLLS HIGHER THAN ENEMY//
        if (playerVesselRollResult > enemyVesselRollResult)
        {
            int dmg = playerVesselRollResult - enemyVesselRollResult;
            enemyVessel.Health -= dmg;
            gm.CombatUIHUD.UpdateCombatText("Enemy takes " + dmg + ".");

            if (enemyVessel.Health < 0)
            {
                enemyVessel.Health = 0;
            }

            gm.CombatUIHUD.UpdateEnemyHealth(enemyVessel.Health);
            

        }
        //IF ENEMY ROLLS HIGHER THAN PLAYER//
        else if (playerVesselRollResult < enemyVesselRollResult)
        {
            int dmg = enemyVesselRollResult - playerVesselRollResult;
            dmg -= playerVesselDefenseBonus;

            //CHECKS ROLL AGAINST DEFENSE BONUS//
            if (dmg > 0)
            {
                gm.Player.Vessel.Health -= dmg;
                gm.CombatUIHUD.UpdateCombatText("Player takes " + dmg + ".");

                if (gm.Player.Vessel.Health < 0)
                {
                    gm.Player.Vessel.Health = 0;
                }

                gm.CombatUIHUD.UpdatePlayerHealth(gm.Player.Vessel.Health);
            } else
            {
                gm.CombatUIHUD.UpdateCombatText("Player negates all damage due to defense bonus.");
            }
            
        }
        //IF PLAYER AND ENEMY ROLL THE SAME//
        else
        {
            gm.CombatUIHUD.UpdateCombatText("Same roll; Actions cancelled out.");
        }
        //ACTIVATE LOSE CONDITION//
        if (gm.Player.Vessel.Health <= 0)
        {
            gm.CombatUIHUD.UpdateCombatText("Player was killed by the enemy.");
            gm.IsPlayerAlive = false;
            IsEventConcluded = true;
            gm.CombatUIHUD.UpdateCombatText("Trigger LOSE condition");
        }
        //ACTIVATE WIN CONDITION//
        if (enemyVessel.Health <= 0)
        {
            gm.CombatUIHUD.UpdateCombatText("Enemy was killed by the player.");
            IsEventConcluded = true;
            gm.CombatUIHUD.UpdateCombatText("Trigger WIN condition");
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
