using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGameStateButton : MonoBehaviour
{
    private Button ChangeStateButton;

    private void Awake()
    {
        ChangeStateButton = this.GetComponent<Button>();

        ChangeStateButton.onClick.AddListener(() => EventManager.Instance.Invoke(EventID.ChangeGameStateButtonClicked));
    }
}
