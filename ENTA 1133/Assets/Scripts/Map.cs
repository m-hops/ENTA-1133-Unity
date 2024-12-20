using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int RoomOffset = 10;
    public Room[,] Rooms;
    public Room StartRoom;
    public Room EnemyRoom;
    public Room TreasureRoom;
    private int EnemyCount = 3;

    public void Setup(GameManager gm, int width, int height, DieRoller dice, int startX, int startY)
    {
        Rooms = new Room[width, height];
        Rooms[startX, startY] = GameObject.Instantiate(StartRoom);
        Rooms[startX, startY].Event = new TreasureEvent();
        List<Room> roomInstances = new List<Room>();
        
        for (int x = 0; x < EnemyCount; x++)
        {
            Room r = GameObject.Instantiate(EnemyRoom);
            r.Event = new CombatEvent();
            roomInstances.Add(r);
        }
        int treasureRoomCount = width * height - 1 -EnemyCount;

        for (int i = 0; i < treasureRoomCount; i++)
        {
            Room r = GameObject.Instantiate(TreasureRoom);
            r.Event = new TreasureEvent();
            roomInstances.Add(r);
        }
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Room r = Rooms[x, y];
                if (r == null)
                {
                    int roomIndex = gm.Dice.Roll(roomInstances.Count)-1;
                    r = roomInstances[roomIndex];
                    Rooms[x, y] = r;
                    roomInstances.RemoveAt(roomIndex);
                }
                r.transform.position = new Vector3(x * RoomOffset, 0, y * RoomOffset);
                r.PosX = x;
                r.PosY = y;

                //CHECKS IF WALL NEEDS TO BE REMOVED TO CONNECTING ROOMS//
                if (r.PosX > 0)
                {
                    r.WestDoor.SetActive(false);
                }
                if (r.PosX < gm.MapWidth-1)
                {
                    r.EastDoor.SetActive(false);
                }
                if (r.PosY > 0)
                {
                    r.SouthDoor.SetActive(false);
                }
                if (r.PosY < gm.MapHeight - 1)
                {
                    r.NorthDoor.SetActive(false);
                }
            }
        }
    }
}
