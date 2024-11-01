using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string Name;
    public int PosX;
    public int PosY;
    public Event Event;
    public GameObject NorthDoor;
    public GameObject SouthDoor;
    public GameObject EastDoor;
    public GameObject WestDoor;

    public void OnDecript(GameManager gm)
    {
        if (Event == null || Event.IsDecrypted)
        {
            Debug.Log("Room is already decrypted");
        }
        else
        {
            Debug.Log("Room is now decrypted");
            Event.Execute(gm);
        }
    }
}
