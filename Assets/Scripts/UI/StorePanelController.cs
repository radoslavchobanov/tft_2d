using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePanelController : MonoBehaviour
{
    private StoreManager StoreManager => GameManager.Instance.StoreManager;

    public List<StoreItemButton> StoreItemButtons;
    public Button RefreshStoreButton;
    public Button BuyXPButton;

    private void Awake()
    {
        foreach (var item in StoreItemButtons)
        {
            if (item == null)
            {
                Debug.Log("StorePanelController: You have not Initialized all StoreItemButtons");
                return;
            }
        }

        RefreshStoreButton.onClick.AddListener(OnRefreshStoreButtonClick);
        BuyXPButton.onClick.AddListener(OnBuyXPButtonClick);

        StoreManager.OnGeneratedItems.AddListener(InitializeStoreItemButtons);
    }

    private void Start()
    {
    }

    private void InitializeStoreItemButtons(List<StoreItem> generatedItems)
    {
        DeactivateStoreItemButtons();
        int i = 0;
        foreach (var item in generatedItems)
        {
            StoreItemButtons[i]?.Initialize(item.UnitName, item.UnitSprite, item.UnitActionOnClick);
            ++i;
        }

        EventManager.Instance.Invoke(EventID.StoreRefreshed);
    }

    private void DeactivateStoreItemButtons()
    {
        StoreItemButtons.ForEach(button => button.Deactivate());
    }

    private void OnRefreshStoreButtonClick()
    {
        // Debug.Log("OnRefreshStoreButtonClick");
        StoreManager.RefreshStore();
    }

    private void OnBuyXPButtonClick()
    {
        Debug.Log("OnBuyXPButtonClick");
        // TODO: logic about the XP
    }
}
