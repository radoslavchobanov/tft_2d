using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _x = 0;
    private int _y = 0;
    [SerializeField] private List<Tile> _neighbourTiles = new();

    public int X => _x;
    public int Y => _y;
    public List<Tile> NeighbourTiles => _neighbourTiles;

    public bool IsOccupied = false;
    public bool IsBenchTile => _y == 0;
    public bool IsBusy = false;

    private void Awake()
    {
    }

    private void Start()
    {
        GetNeighbourTiles();
    }

    private void Update()
    {
        if (GetObjectOnTile() == null) IsOccupied = false;
        else IsOccupied = true;
    }

    private void GetNeighbourTiles()
    {
        GetNeighbourTile(X, Y - 1);
        GetNeighbourTile(X - 1, Y);
        GetNeighbourTile(X + 1, Y);
        GetNeighbourTile(X, Y + 1);

        // on even row
        if (_y % 2 == 0 || _y == 0)
        {
            GetNeighbourTile(X - 1, Y - 1);
            GetNeighbourTile(X - 1, Y + 1);
        }
        // on odd row
        else
        {
            GetNeighbourTile(X + 1, Y + 1);
            GetNeighbourTile(X + 1, Y - 1);
        }
    }

    private void GetNeighbourTile(int x, int y)
    {
        var tile = MapManager.GetTile(x, y);
        if (tile != null)
        {
            _neighbourTiles.Add(tile);
        }
    }

    public void ChangeMaterial(Material mat)
    {
        this.TryGetComponent<MeshRenderer>(out MeshRenderer mesh);
        mesh.material = mat;
    }

    public void CreateTile(int x, int y)
    {
        this._x = x;
        this._y = y;

        this.name = "Tile (" + x + ", " + y + ")";
        this.tag = Constants.TILE_TAG;

        MapManager.Tiles.Add(this);
        if (_y >= 0 && _y <= 4)
        {
            MapManager.AllyTiles.Add(this);
            if (_y == 0) MapManager.AllyTilesOnBench.Add(this);
            else if (_y > 0) MapManager.AllyTilesOnBattleground.Add(this);
        }
        else if (_y > 4 && _y <= 9)
        {
            MapManager.EnemyTiles.Add(this);
        }
    }

    public GameObject GetObjectOnTile()
    {
        return GameManager.GetGameobjectInFrontPoint(transform.position);
    }
}
