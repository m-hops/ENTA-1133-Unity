using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DieRoller Dice = new DieRoller();
    public Dialog Dialog = new Dialog();
    public Player Player;
    public Map Map;
    [Range (1,3)]
    public int MapWidth = 3;
    [Range(1, 3)]
    public int MapHeight = 3;
    public List<Vessel> EnemyVessels;
    public List<Weapon> TreasurePoolWeapons = new List<Weapon>();
    public List<Item> TreasurePoolConsumable = new List<Item>();
    public List<Item> TreasurePoolPassive = new List<Item>();

    public bool IsGameRunning = false;
    public bool IsPlayerAlive = false;
    //public Room CurrentPlayerRoom => Map.Rooms[Player.CurrentX, Player.CurrentY];

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
