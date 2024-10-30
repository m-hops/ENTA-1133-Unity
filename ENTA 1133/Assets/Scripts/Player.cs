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
    public Direction CurrentDirection;

    public void TurnLeft(Map map)
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
        CurretAngle -= 90;

        if (CurretAngle < -1)
        {
            CurretAngle = 270;
        }
        gameObject.transform.rotation = Quaternion.Euler(0, CurretAngle, 0);
        //gameObject.transform.rotation = Quaternion.Euler(0, CurretAngle, 0);

        Debug.Log("Turns Left");
    }

    public void TurnRight(Map map)
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
        CurretAngle += 90;
        gameObject.transform.rotation = Quaternion.Euler(0, CurretAngle, 0);

        Debug.Log("Turns Right");
    }

    public void MoveForward()
    {
        float currentX = gameObject.transform.position.x;
        float currentY = gameObject.transform.position.y;
        float currentZ = gameObject.transform.position.z;
        int moveAmount = 10;

        if (CurretAngle == 0)
        {
            gameObject.transform.position = new Vector3(currentX, currentY, currentZ + moveAmount);
        } 
        

    }

    private void UpdatePlayerObjectPosition(Map map)
    {
        switch (CurrentDirection)
        {
            case Direction.North:
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.East:
                gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
            case Direction.South:
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case Direction.West:
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }

        gameObject.transform.position = new Vector3(currentX, currentY, currentZ + moveAmount);
    }
}
