using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArcadeUIStateMachine : MonoBehaviour
{
    public GameObject Loading;
    public GameObject Navigation;
    public GameObject Combat;
    public GameObject Inventory;
    public GameObject ShipSelect;
    public GameObject GetItem;

    public void LoadingScreen()
    {
        Loading.SetActive(true);
        Navigation.SetActive(false);
        Combat.SetActive(false);
        Inventory.SetActive(false);
        ShipSelect.SetActive(false);
    }
    public void NavigationScreen()
    {
        Loading.SetActive(false);
        Navigation.SetActive(true);
        Combat.SetActive(false);
        Inventory.SetActive(false);
        ShipSelect.SetActive(false);
    }
    public void CombatScreen()
    {
        Loading.SetActive(false);
        Navigation.SetActive(false);
        Combat.SetActive(true);
        Inventory.SetActive(false);
        ShipSelect.SetActive(false);
    }
    public void InventoryScreen()
    {
        Loading.SetActive(false);
        Navigation.SetActive(false);
        Combat.SetActive(false);
        Inventory.SetActive(true);
        ShipSelect.SetActive(false);
    }
    public void VesselSelectScreen()
    {
        Loading.SetActive(false);
        Navigation.SetActive(false);
        Combat.SetActive(false);
        Inventory.SetActive(false);
        ShipSelect.SetActive(true);
    }
    public void CloseGetItem()
    {
        GetItem.SetActive(false);
    }
    public void DownButtonColorChange(Image image)
    {
        image.GetComponent<Image>().color = new Color(255, 0, 0);
    }
    public void UpButtonColorChange(Image image)
    {
        image.GetComponent<Image>().color = new Color(255, 255, 255);
    }
}
