using UnityEngine;

public class MapController
{
    public int gridWidth = 10;
    public int gridHeight = 10;

    float hexWidth = 1.732f;
    float hexHeight = 2;
    public float gap = 0.02f;

    Vector2 startPos;

    public void CreateMap(GameObject tilesParent, GameObject tilePrefab)
    {
        AddGap();
        CalcStartPos();
        CreateGrid(tilesParent, tilePrefab);
    }

    void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    void CalcStartPos()
    {
        startPos = Vector2.zero;
    }

    Vector2 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float y = startPos.y + gridPos.y * hexHeight * 0.75f;

        return new Vector2(x, y);
    }

    void CreateGrid(GameObject tilesParent, GameObject tilePrefab)
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Vector2 gridPos = new Vector2(x, y);
                GameObject hex = MonoBehaviour.Instantiate(tilePrefab, CalcWorldPos(gridPos), Quaternion.identity);
                hex.transform.parent = tilesParent.transform;

                hex.GetComponent<MeshCollider>().convex = true;
                hex.AddComponent<Tile>().CreateTile(x, y);
            }
        }
    }

    private bool IsAllyTile(GameObject tileObj)
    {
        return tileObj.transform.position.y < 6;
    }
}
