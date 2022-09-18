using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _x = 0;
    private int _y = 0;

    public int X => _x;
    public int Y => _y;

    public bool occupied = false;

    public bool IsBenchTile => _y == 0;

    private void Awake() 
    {
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (GetObjectOnTile() == null) occupied = false;
        else occupied = true;
    }

    public void CreateTile(int x, int y)
    {
        this._x = x;
        this._y = y;
        
        this.name = "Tile (" + x + ", " + y + ")";
        this.tag = Constants.TILE_TAG;
        
        GameManager.Singleton.MapManager.Tiles.Add(this);
        if (_y >= 0 && _y <= 4)
        {
            GameManager.Singleton.MapManager.AllyTiles.Add(this);
            if (_y == 0) GameManager.Singleton.MapManager.AllyTilesOnBench.Add(this);
            else if (_y > 0) GameManager.Singleton.MapManager.AllyTilesOnBattleground.Add(this);
        }
        else if (_y > 4 && _y <= 9)
        {
            GameManager.Singleton.MapManager.EnemyTiles.Add(this);
        }
    }

    public GameObject GetObjectOnTile()
    {
        return GameManager.GetGameobjectInFrontPoint(transform.position);
    }
}
