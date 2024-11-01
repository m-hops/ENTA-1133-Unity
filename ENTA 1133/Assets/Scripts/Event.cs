using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event
{
    public bool IsDecrypted = false;
    public bool IsEventConcluded = false;
    public abstract void Execute(GameManager gm);
}
