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
    
    private GameObject ShipSelectSlot0;

    public void Start()
    {
        ShipSelectSlot0 = ShipSelect.transform.Find("ShipSlot0").gameObject;
    }

    public void LoadingScreen()
    {
        Loading.SetActive(true);
        Navigation.SetActive(false);
        Combat.SetActive(false);
        Inventory.SetActive(false);
    }
    public void NavigationScreen()
    {
        Loading.SetActive(false);
        Navigation.SetActive(true);
        Combat.SetActive(false);
        Inventory.SetActive(false);
    }
    public void CombatScreen()
    {
        Loading.SetActive(false);
        Navigation.SetActive(false);
        Combat.SetActive(true);
        Inventory.SetActive(false);
    }
    public void InventoryScreen()
    {
        Loading.SetActive(false);
        Navigation.SetActive(false);
        Combat.SetActive(false);
        Inventory.SetActive(true);
    }
    public void VesselSelectScreen()
    {


    }
    public void DisplayShipInfoSlot(VesselSelectCard vsc, GameObject vessel)
    {
        //vsc.Name = ShipSelectSlot0.GetComponent<TextMeshProUGUI>.
    }
}
