using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North,
    East,
    South,
    West

}

public class Player : MonoBehaviour
{
    public float CurretAngle;
    public int CurrentX;
    public int CurrentY;
    public int AttackBonus;
    public int DefenseBonus;
    public Vessel Vessel;
    private Direction CurrentDirection;
    public Map Map;
    public GameManager GM;
    public GameObject ObjectSpawnArea;

    public void Start()
    {
        AttackBonus = 0;
        DefenseBonus = 0;

        CurrentDirection = Direction.North;

        CurrentX = GM.MapWidth / 2;
        CurrentY = GM.MapHeight / 2;

        UpdatePlayerTransform();
    }

    //PLAYER MOVEMENT CONTROLS
    public void TurnLeft()
    {
        switch (CurrentDirection)
        {
            case Direction.North:
                CurrentDirection = Direction.West;
                break;
            case Direction.East:
                CurrentDirection = Direction.North;
                break;
            case Direction.South:
                CurrentDirection = Direction.East;
                break;
            case Direction.West:
                CurrentDirection = Direction.South;
                break;
        }
        UpdatePlayerTransform();
    }
    public void TurnRight()
    {
        switch (CurrentDirection)
        {
            case Direction.North:
                CurrentDirection = Direction.East;
                break;
            case Direction.East:
                CurrentDirection = Direction.South;
                break;
            case Direction.South:
                CurrentDirection = Direction.West;
                break;
            case Direction.West:
                CurrentDirection = Direction.North;
                break;
        }
        UpdatePlayerTransform();
    }
    public void MoveForward()
    {
        float y = gameObject.transform.position.y;

        switch (CurrentDirection)
        {
            case Direction.North:
                if (CurrentY < (GM.MapHeight-1))
                {
                    CurrentY++;
                    UpdatePlayerTransform();
                }
                break;
            case Direction.East:
                if (CurrentX < (GM.MapWidth - 1))
                {
                    CurrentX++;
                    UpdatePlayerTransform();
                }
                break;
            case Direction.South:
                if (CurrentY > 0)
                {
                    CurrentY--;
                    UpdatePlayerTransform();
                }
                break;
            case Direction.West:
                if (CurrentX > 0)
                {
                    CurrentX--;
                    UpdatePlayerTransform();
                }
                break;
        }

    }
    private void UpdatePlayerTransform()
    {
        switch (CurrentDirection)
        {
            case Direction.North:
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.East:
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case Direction.South:
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case Direction.West:
                gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
        }
        float y = gameObject.transform.position.y;
        gameObject.transform.position = new Vector3(CurrentX * Map.RoomOffset, y, CurrentY * Map.RoomOffset);
    }
}
