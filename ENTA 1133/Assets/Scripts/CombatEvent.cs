using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvent : Event
{
    public int RoundCounter = 0;

    public override void Execute(GameManager gm)
    {
        
    }

    public void CombatRound(GameManager gm, Vessel enemyVessel)
    {
        int playerVesselWeaponIndex = -1;

        while (playerVesselWeaponIndex < 0)
        {

        }
    }

    public void Lose()
    {

    }

    public void Win()
    {

    }

}
