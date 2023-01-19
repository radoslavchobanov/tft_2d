using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.Register(EventID.MouseLeftClicked, OnMouseLeftClicked);
        EventManager.Instance.Register(EventID.MouseRightClicked, OnMouseRightClicked);
    }

    private void Update()
    {
        // Mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.Instance.Invoke(EventID.MouseLeftClicked, GameManager.GetMouseScreenPosition());
        }
        // Mouse right click
        if (Input.GetMouseButtonDown(1))
        {
            EventManager.Instance.Invoke(EventID.MouseRightClicked, GameManager.GetMouseScreenPosition());
        }
    }

    private void OnMouseLeftClicked(object args)
    {
        Vector2 clickedPoint = (Vector2)args;

        // clicked over UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        var clickedObj = GameManager.GetGameobjectBehindScreenPoint(clickedPoint);
        if (clickedObj == null)
        {
            Debug.Log("EventManager: No Object is clicked !");
            return;
        }
        // Debug.Log("EventManager: " + obj.name + " Clicked");

        // check for clicked gameobject in the world
        if (GameManager.Instance.IsObjectAllyUnit(clickedObj))
        {
            clickedObj.TryGetComponent<Unit>(out Unit unit);
            EventManager.Instance.Invoke(EventID.AllyUnitLeftClicked, unit);
        }
        else if (GameManager.Instance.IsObjectAllyTile(clickedObj))
        {
            EventManager.Instance.Invoke(EventID.AllyTileClicked, clickedObj);
        }
    }
    
    private void OnMouseRightClicked(object args)
    {
        Vector2 clickedPoint = (Vector2)args;

        // clicked over UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        var clickedObj = GameManager.GetGameobjectBehindScreenPoint(clickedPoint);
        if (clickedObj == null)
        {
            Debug.Log("EventManager: No Object is clicked !");
            return;
        }
        // Debug.Log("EventManager: " + obj.name + " Clicked");

        // check for clicked gameobject in the world
        if (GameManager.Instance.IsObjectUnit(clickedObj))
        {
            clickedObj.TryGetComponent<Unit>(out Unit unit);
            EventManager.Instance.Invoke(EventID.UnitRightClicked, unit);
        }
    }
}
