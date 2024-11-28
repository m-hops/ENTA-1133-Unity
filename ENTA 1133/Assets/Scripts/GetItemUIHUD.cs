using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemUIHUD : MonoBehaviour
{
    public TMPro.TMP_Text Description;
    public TMPro.TMP_Text ItemName;
    public Image Icon;

    public void PopupInfo(Item item)
    {
        ItemName.text = item.Name;
        Description.text = item.Description;
        Icon.sprite = item.Sprite;
    }
}
