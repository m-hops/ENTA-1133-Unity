using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] public int Name;
    [SerializeField] public int PosX;
    [SerializeField] public int PosY;
    [SerializeField] public string Description;
    [SerializeField] public Event Event;
    [SerializeField] public GameObject NorthDoor;
    [SerializeField] public GameObject SouthDoor;
    [SerializeField] public GameObject EastDoor;
    [SerializeField] public GameObject WestDoor;
}
