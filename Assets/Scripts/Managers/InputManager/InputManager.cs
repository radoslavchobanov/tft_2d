using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputEvents InputEvents => GameManager.Singleton.EventManager.InputEvents;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InputEvents.MouseLeftClicked.Invoke(GameManager.GetMouseScreenPosition());
        }
    }
}
