using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public partial class MapManager : MonoBehaviour
{
    private MapController _mapController = new();

    public GameObject MapContent;

    public GameObject TilePrefab;
    public Material DefaultMaterial;
    public Material SelectableMaterial;
    public Material PointedMaterial;

    public static List<Tile> Tiles = new(); // All tiles
    public static List<Tile> AllyTiles = new(); // All Ally tiles
    public static List<Tile> AllyTilesOnBench = new(); // All Ally tiles on the bench
    public static List<Tile> AllyTilesOnBattleground = new(); // All Ally tiles on the battleground
    public static List<Tile> EnemyTiles = new(); // All Ally tiles

    private static Vector2 Graveyard = new Vector2(1000, 1000);

    private void Awake()
    {
        _mapController.CreateMap(MapContent, TilePrefab);
    }

    private void Start()
    {
        RegisterEvents();
    }

    private void Update()
    {
    }

    private static void ChangeMaterialOnTiles(List<Tile> tileList, Material mat)
    {
        foreach (Tile tile in tileList)
        {
            tile.ChangeMaterial(mat);
        }
    }

    private void MakeAllyTilesSelectable()
    {
        ChangeMaterialOnTiles(AllyTiles, SelectableMaterial);
    }

    private void ClearAllySelectableTiles()
    {
        ChangeMaterialOnTiles(AllyTiles, DefaultMaterial);
    }

    public static Tile GetNextAvailableTileOnBench()
    {
        foreach (Tile tile in AllyTilesOnBench)
            if (tile.IsOccupied == false)
                return tile;
        return null;
    }

    public static Tile GetTile(int x, int y)
    {
        foreach (Tile tile in Tiles)
            if (tile.X == x && tile.Y == y)
                return tile;
        return null;
    }

    // TODO: Think if this should be in UnitManager
    public static void SendToGraveyard(Unit unit)
    {
        unit.transform.position = Graveyard;
    }
}
