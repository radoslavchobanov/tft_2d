using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StoreItemButton : MonoBehaviour
{
    public Text UnitName;
    public Image UnitImage;
    public Button UnitButton;

    public void Initialize(string unitName, Sprite unitSprite, UnityAction action)
    {
        this.UnitName.text = unitName;
        this.UnitImage.sprite = unitSprite;
        this.UnitButton.onClick.AddListener(action);
    }

    public void Deactivate()
    {
        this.UnitName.text = string.Empty;
        this.UnitImage.sprite = null;
        this.UnitButton.onClick.RemoveAllListeners();
    }
}
