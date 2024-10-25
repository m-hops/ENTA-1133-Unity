using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int RoomName = 0;
    public Room[,] Rooms;
    public List<Room> availableRooms = new List<Room>();
}
