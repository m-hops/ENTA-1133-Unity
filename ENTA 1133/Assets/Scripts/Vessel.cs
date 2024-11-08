using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    public string Name;
    public int Health;
    public Sprite Sprite;
    public Weapon[] Weapons = new Weapon[kWeaponCount];
    [HideInInspector] public List<int> WeaponsReady = new List<int>();
    public const int kWeaponCount = 4;

    public Vessel(string name, int health)
    {
        Name = name;
        Health = health;
    }

    //ASSIGN WEAPON TO WEAPON SLOT//
    public void SetWeapon(Weapon weapon, int weaponSlotIndex)
    {
        Weapons[weaponSlotIndex] = weapon;
        if (!WeaponsReady.Contains(weaponSlotIndex))
        {
            WeaponsReady.Add(weaponSlotIndex);
        }
    }
    //FIND WEAPON BY NAME//
    public int GetWeaponIndexByName(string weaponName)
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            if (Weapons[i].Name == weaponName)
            {
                return i;
            }
        }

        //IF WEAPON NOT AVAILABLE, -1 WILL RE PROMPT PLAYER FOR INPUT//
        return -1;
    }
    //CHECKS ARRAY TO SEE IF WEAPON IS AVAILABLE//
    public int GetAvailableWeaponIndexByName(string weaponName)
    {
        for (int i = 0; i < WeaponsReady.Count; i++)
        {
            int weaponIndex = WeaponsReady[i];
            if (Weapons[weaponIndex].Name == weaponName)
            {
                WeaponsReady.RemoveAt(i);
                return weaponIndex;
            }
        }

        //IF WEAPON NOT AVAILABLE, -1 WILL RE PROMPT PLAYER FOR INPUT//
        return -1;
    }
    //WEAPON RANDOMIZER FOR CPU ENEMY//
    public int GetRandomAvailableWeaponIndex(DieRoller dice)
    {
        int result = dice.Roll(WeaponsReady.Count) - 1;
        int weaponIndex = WeaponsReady[result];
        WeaponsReady.RemoveAt(result);
        return weaponIndex;

    }
    //RESET WEAPONS WHEN WEAPON POOL HAS BEEN DEPLETED//
    public void ResetWeapons()
    {
        WeaponsReady.Clear();

        for (int i = 0; i < kWeaponCount; i++)
        {
            WeaponsReady.Add(i);
        }
    }
    public bool IsWeaponIndexReady(int weaponSlotIndex)
    {
        return WeaponsReady.Contains(weaponSlotIndex);
    }
    public void SetWeaponUsed(int weaponSlotIndex)
    {
        WeaponsReady.Remove(weaponSlotIndex);
    }
}
