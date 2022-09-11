using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    private InputEvents _inputEvents = new();
    private GameEvents _gameEvents = new();
    private UIEvents _uiEvents = new();

    public InputEvents InputEvents => _inputEvents;
    public GameEvents GameEvents => _gameEvents;
    public UIEvents UIEvents => _uiEvents;

    private void Awake()
    {
        InputEvents.MouseLeftClicked.AddListener(OnMouseLeftClicked);
    }

    private void OnMouseLeftClicked(Vector2 clickedPoint)
    {
        // clicked over UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        var clickedObj = GameManager.GetGameobjectBehindPoint(clickedPoint);
        if (clickedObj == null)
        {
            Debug.Log("EventManager: No Object is clicked !");
            return;
        }
        // Debug.Log("EventManager: " + obj.name + " Clicked");

        // check for clicked gameobject in the world
        if (GameManager.Singleton.IsObjectAllyUnit(clickedObj))
        {
            clickedObj.TryGetComponent<Unit>(out Unit unit);
            GameEvents?.AllyUnitClicked.Invoke(unit);
        }
        else if (GameManager.Singleton.IsObjectAllyTile(clickedObj))
            GameEvents?.AllyTileClicked.Invoke(clickedObj);
    }
}
