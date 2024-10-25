using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour
{
    int mapSize = 3;
    public int MapSize => mapSize;
    RoomBase[] Rooms;

    private void Start()
    {
        CreateMap();
        VisualizeMap();
    }

    private void CreateMap()
    {

    }

    private void VisualizeMap()
    {
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                var mapRoomRepresentation = GameObject.CreatePrimitive
                    (PrimitiveType.Sphere);
                mapRoomRepresentation.transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
