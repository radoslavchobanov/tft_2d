using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public partial class MapManager : MonoBehaviour
{
    private GameEvents GameEvents => GameManager.Singleton.EventManager.GameEvents;
    private MapController _mapController = new();

    public GameObject MapContent;

    public GameObject TilePrefab;
    public Material DefaultMaterial;
    public Material SelectableMaterial;
    public Material PointedMaterial;

    public List<Tile> Tiles = new(); // All tiles
    public List<Tile> AllyTiles = new(); // All Ally tiles
    public List<Tile> AllyTilesOnBench = new(); // All Ally tiles on the bench
    public List<Tile> AllyTilesOnBattleground = new(); // All Ally tiles on the battleground
    public List<Tile> EnemyTiles = new(); // All Ally tiles

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
        MeshRenderer mesh = null;
        foreach (Tile tile in tileList)
        {
            tile.TryGetComponent<MeshRenderer>(out mesh);
            mesh.material = mat;
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

    public Tile GetNextAvailableTileOnBench()
    {
        foreach (Tile tile in AllyTilesOnBench)
        {
            if (tile.occupied == false)
            {
                return tile;
            }
        }
        return null;
    }
    
    public static void SendToGraveyard(Unit unit)
    {
        unit.transform.position = Graveyard;
    }
}
