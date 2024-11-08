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
        gm.AudioStateMachine.currentPitchAdjustment -= gm.AudioStateMachine.pitchOffset;
        EnemyVessel = GameObject.Instantiate(gm.EnemyVesselsPool[0], gm.Player.ObjectSpawnArea.transform);
        gm.EnemyVesselsPool.RemoveAt(0);
        EnemyVessel.ResetWeapons();
        gm.Player.Vessel.ResetWeapons();

        gm.CombatUIHUD.SetupCombatEventUI(this);

        CombatRoundStage1(gm);
    }
    //BEHAVIOUR FOR A SINGLE ROUND OF COMBAT//
    public void CombatRoundStage1(GameManager gm)
    {
        gm.CombatUIHUD.ShowCombatRound(gm.Player.Vessel, EnemyVessel);
    }
    //BEHAVIOUR FOR A SINGLE ROUND OF COMBAT//
    public void CombatRoundStage2(GameManager gm, int playerVesselWeaponIndex)
    {
        gm.Player.Vessel.SetWeaponUsed(playerVesselWeaponIndex);
        //SETUP FOR COMBAT CALCULATIONS//
        int enemyVesselWeaponIndex = EnemyVessel.GetRandomAvailableWeaponIndex(gm.Dice);
        string enemyVesselCurrentWeapon = EnemyVessel.Weapons[enemyVesselWeaponIndex].Name;
        string playerVesselCurrentWeapon = gm.Player.Vessel.Weapons[playerVesselWeaponIndex].Name;
        int playerVesselDice = gm.Player.Vessel.Weapons[playerVesselWeaponIndex].PowerLevel;
        int enemyVesselDice = EnemyVessel.Weapons[playerVesselWeaponIndex].PowerLevel;
        int playerVesselRollResult = gm.Dice.Roll(playerVesselDice);
        int enemyVesselRollResult = gm.Dice.Roll(enemyVesselDice);
        int playerVesselAttackBonus = gm.Player.AttackBonus;
        int playerVesselDefenseBonus = gm.Player.DefenseBonus;
        playerVesselRollResult += playerVesselAttackBonus;

        //IF PLAYER ROLLS HIGHER THAN ENEMY//
        if (playerVesselRollResult > enemyVesselRollResult)
        {
            int dmg = playerVesselRollResult - enemyVesselRollResult;
            EnemyVessel.Health -= dmg;
            gm.CombatUIHUD.UpdateCombatText("Enemy takes " + dmg + ".");

            if (EnemyVessel.Health < 0)
            {
                EnemyVessel.Health = 0;
            }

            gm.CombatUIHUD.UpdateEnemyHealth(EnemyVessel.Health);


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
            }
            else
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
            Debug.Log("Trigger LOSE condition");
            gm.AudioStateMachine.SoundtrackStateMachine(0, gm.AudioStateMachine.currentPitchAdjustment);
        }
        //ACTIVATE WIN CONDITION//
        else if (EnemyVessel.Health <= 0)
        {
            gm.CombatUIHUD.UpdateCombatText("Enemy was killed by the player.");
            IsEventConcluded = true;
            Debug.Log("Trigger WIN condition");
            GameObject.Destroy(EnemyVessel.gameObject);
            gm.AudioStateMachine.SoundtrackStateMachine(0, gm.AudioStateMachine.currentPitchAdjustment);
        }
        else
        {
            RoundCounter++;
            if (RoundCounter % Vessel.kWeaponCount == 0)
            {
                gm.Player.Vessel.ResetWeapons();
                EnemyVessel.ResetWeapons();
            }
        }
        
        if (!IsEventConcluded)
        {
            CombatRoundStage1(gm);
        } else
        {
            //SETS ROOM TO TO DECRYPTED AFTER COMBAT;
            IsDecrypted = true;
            if (gm.EnemyVesselsPool.Count == 0)
            {
                Win(gm);
            }
            gm.CombatUIHUD.ArcadeUIStateMachine.NavigationScreen();
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
