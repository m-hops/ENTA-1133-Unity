using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelectUIHD : MonoBehaviour
{
    public GameObject ShipSlot0;
    public GameObject ShipSlot1;
    public GameObject ShipSlot2;
    public GameManager GM;
    public ArcadeUIStateMachine ArcadeUIStateMachine;

    public void Start()
    {
        SetupSlot(ShipSlot0, 0);
        SetupSlot(ShipSlot1, 1);
        SetupSlot(ShipSlot2, 2);
    }
    public void SelectPlayerVessel(int vesselIndex)
    {
        Vessel response = GM.PlayerVesselPool[vesselIndex];
        GM.Player.Vessel = GameObject.Instantiate(response);
        ArcadeUIStateMachine.NavigationScreen();

    }
    public void SetupSlot(GameObject ship, int vesselIndex)
    {
        TMPro.TMP_Text name = ship.gameObject.transform.Find("Name").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text hp = ship.gameObject.transform.Find("HP").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon0Name = ship.gameObject.transform.Find("Weapon0Name").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon0Power = ship.gameObject.transform.Find("Weapon0Power").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon1Name = ship.gameObject.transform.Find("Weapon1Name").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon1Power = ship.gameObject.transform.Find("Weapon1Power").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon2Name = ship.gameObject.transform.Find("Weapon2Name").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon2Power = ship.gameObject.transform.Find("Weapon2Power").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon3Name = ship.gameObject.transform.Find("Weapon3Name").GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text weapon3Power = ship.gameObject.transform.Find("Weapon3Power").GetComponent<TMPro.TMP_Text>();
        Image ShipSlot_icon = ship.gameObject.transform.Find("Icon").GetComponent<Image>();

        name.text = GM.PlayerVesselPool[vesselIndex].Name;
        hp.text = "Health: " + GM.PlayerVesselPool[vesselIndex].Health.ToString();
        ShipSlot_icon.sprite = GM.PlayerVesselPool[vesselIndex].Sprite;
        weapon0Name.text = GM.PlayerVesselPool[vesselIndex].Weapons[0].Name;
        weapon0Power.text = "1-" + GM.PlayerVesselPool[vesselIndex].Weapons[0].PowerLevel.ToString();
        weapon1Name.text = GM.PlayerVesselPool[vesselIndex].Weapons[1].Name;
        weapon1Power.text = "1-" + GM.PlayerVesselPool[vesselIndex].Weapons[1].PowerLevel.ToString();
        weapon2Name.text = GM.PlayerVesselPool[vesselIndex].Weapons[2].Name;
        weapon2Power.text = "1-" + GM.PlayerVesselPool[vesselIndex].Weapons[2].PowerLevel.ToString();
        weapon3Name.text = GM.PlayerVesselPool[vesselIndex].Weapons[3].Name;
        weapon3Power.text = "1-" + GM.PlayerVesselPool[vesselIndex].Weapons[3].PowerLevel.ToString();
    }

}
