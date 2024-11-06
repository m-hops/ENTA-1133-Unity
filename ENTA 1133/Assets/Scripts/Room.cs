using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string Name;
    public int PosX;
    public int PosY;
    public GameObject Encrypted;
    public GameObject Decrypted;
    public Event Event;
    public GameObject NorthDoor;
    public GameObject SouthDoor;
    public GameObject EastDoor;
    public GameObject WestDoor;

    public Room (string name, int posX, int posY, Event roomEvent, GameObject encrypted, GameObject decrypted)
    {
        Name = name;
        PosX = posX;
        PosY = posY;
        Event = roomEvent;
        Encrypted = encrypted;
        Decrypted = decrypted;
    }

    public void OnDecript(GameManager gm)
    {
        if (Event == null || Event.IsDecrypted)
        {
            Debug.Log("Room is already decrypted");
        }
        else
        {
            Encrypted.SetActive(false);
            Decrypted.SetActive(true);
            Debug.Log("Room is now decrypted");
            Event.Execute(gm);
        }
    }
}
