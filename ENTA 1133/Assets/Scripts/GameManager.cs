using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public DieRoller Dice = new DieRoller();
    public Player Player;
    public Map Map;
    public CombatUIHUD CombatUIHUD;

    [Range (1,3)]
    public int MapWidth = 3;
    [Range(1, 3)]
    public int MapHeight = 3;

    public List<Vessel> EnemyVesselsPool = new List<Vessel>();
    public List<Vessel> PlayerVesselPool = new List<Vessel>();
    public List<Weapon> TreasurePoolWeapons = new List<Weapon>();
    public List<Item> TreasurePoolConsumable = new List<Item>();
    public List<Item> TreasurePoolPassive = new List<Item>();

    public Room CurrentPlayerRoom => Map.Rooms[Player.CurrentX, Player.CurrentY];

    public bool IsGameRunning = false;
    public bool IsPlayerAlive = false;

    public const int k_FirstEnemyVesselPresetIndex = 3;

    public void Start()
    {

        Map.Setup(this, MapWidth, MapHeight, Dice, 1, 1);

    }

    public void Update()
    {
      while (IsGameRunning)
        {

        }
    }

}
