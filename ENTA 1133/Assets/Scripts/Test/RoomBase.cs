using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
    [SerializeField] private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoorway;

    public void SetRooms(RoomBase north, RoomBase east, RoomBase south, RoomBase west)
    {
        _north = north;
        NorthDoorway.SetActive(_north == null);
        _east = east;
        EastDoorway.SetActive(_east == null);
        _south = south;
        SouthDoorway.SetActive(_south == null);
        _west = west;
        WestDoorway.SetActive(_west == null);
    }
}
