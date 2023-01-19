using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas UICanvas;
    public GameObject StorePanel;

    public Button ChangeGameStateButton;

    private void Awake() 
    {
        UICanvas.gameObject.SetActive(true);

        ChangeGameStateButton.onClick.AddListener(OnChangeGameStateButtonClick);
    }

    private void OnChangeGameStateButtonClick()
    {
        EventManager.Instance.Invoke(EventID.ChangeGameStateButtonClicked);
    }
}
