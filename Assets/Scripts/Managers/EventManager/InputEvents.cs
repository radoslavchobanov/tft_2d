using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputEvents
{
    public UnityEvent<Vector2> MouseLeftClicked = new();
    public UnityEvent<Vector2> MouseRightClicked = new();
}
