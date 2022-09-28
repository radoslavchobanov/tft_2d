using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputEvents InputEvents => GameManager.Singleton.EventManager.InputEvents;

    private void Update()
    {
        // Mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            InputEvents.MouseLeftClicked.Invoke(GameManager.GetMouseScreenPosition());
        }
        // Mouse right click
        if (Input.GetMouseButtonDown(1))
        {
            InputEvents.MouseRightClicked.Invoke(GameManager.GetMouseScreenPosition());
        }
    }
}
