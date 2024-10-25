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

    //PRESET SHIP POOLS//
    //FIRST 3 ARE PLAYER CHOICE & THE REST ARE ENEMY NPCS//
    public readonly string[] kVesselPresetTypes = new string[]
    {
            "BODY",
            "MIND",
            "HOLISTIC",
            "THE TRU MAN",
            "SIXTY ONE PIGS",
            "DALLAS"
    };
    public readonly string[][] kVesselPresetWeaponNames = new string[][]
    {
            new string[] {"INVESTIGATE", "QUESTION", "PUNCH", "HANDGUN"},
            new string[] {"INVESTIGATE", "QUESTION", "MEDITATE", "DOWSING"},
            new string[] {"INVESTIGATE", "INVESTIGATE", "PUNCH", "DREAM"},
            new string[] {"ENOLA", "NATO", "POINT FOUR", "BIRTH"},
            new string[] {"DWISEN", "AIR STRIKE", "SEED", "CMC SIXTY TWO"},
            new string[] {"JACK", "ELM", "GNOLL", "REVENGE"}
    };
    public readonly int[][] kVesselPresetWeaponAttacks = new int[][]
    {
            new int[] {5, 10, 20, 25},
            new int[] {5, 10, 15, 35},
            new int[] {5, 5, 20, 30},
            new int[] {5, 10, 15, 20},
            new int[] {10, 15, 25, 30},
            new int[] {15, 20, 30, 35}
    };
    public readonly int[] kVesselPresetHP = new int[]
    {
            50,
            40,
            45,
            20,
            30,
            40
    };
    public const int k_FirstEnemyVesselPresetIndex = 3;

    public void GameSetup()
    {
       
    }
}
