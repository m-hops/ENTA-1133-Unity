using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieRoller
{
    //SINGLE DICE ROLL BASED ON A MAX VALUE//
    //RETURNS AN INT VALUE//
    public int Roll(int maxVal)
    {
        int rollVal = Random.Range(1, maxVal);
        return rollVal;

    }
}
