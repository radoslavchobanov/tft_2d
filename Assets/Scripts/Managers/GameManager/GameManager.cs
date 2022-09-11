using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public GameController GameController { get; private set; }

    public EventManager EventManager;
    public InputManager InputManager;
    public UIManager UIManager;
    public MapManager MapManager;
    public UnitManager UnitManager;
    public StoreManager StoreManager;
    public ResourceManager ResourceManager;

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;

        GameController = this.GetComponent<GameController>();
        
        // TODO: Check for attached managers
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public bool IsObjectAllyUnit(GameObject obj)
    {
        return obj.CompareTag(Constants.ALLY_UNIT_TAG);
    }
    public bool IsObjectEnemyUnit(GameObject obj)
    {
        return obj.CompareTag(Constants.ENEMY_UNIT_TAG);
    }

    public bool IsObjectAllyTile(GameObject obj)
    {
        Tile tile = null;
        obj.TryGetComponent<Tile>(out tile);
        foreach (Tile t in MapManager.AllyTiles)
        {
            if (t == tile) return true;
        }
        return false;
    }

    public static Vector2 GetMouseScreenPosition()
    {
        return Input.mousePosition;
    }

    public static Vector2 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static GameObject GetGameobjectBehindPoint(Vector2 point)
    {
        return Physics.Raycast(Camera.main.ScreenPointToRay(point), out RaycastHit hit) ? hit.transform.gameObject : null;
    }

    public static GameObject GetGameobjectInFrontPoint(Vector2 point)
    {
        return Physics.Raycast(point, Vector3.back, out RaycastHit hit) ? hit.transform.gameObject : null;
    }
}
