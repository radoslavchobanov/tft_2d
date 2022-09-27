using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceManager : MonoBehaviour
{
    public static List<GameObject> AllAllyUnitPrefabs = new();
    public static List<Sprite> AllAllyUnitSprites = new();

    private void Awake()
    {
        AllAllyUnitPrefabs = GetAllResourcesGameobjects(Constants.ALLY_UNITS_PREFABS_FOLDER_PATH);
        AllAllyUnitSprites = GetAllResourcesSprites(Constants.ALLY_UNITS_SPRITES_FOLDER_PATH);
    }

    private void Start()
    {
    }

    public static Sprite GetUnitSprite(string unitName)
    {
        foreach (var sprite in AllAllyUnitSprites)
            if (sprite.name == unitName) return sprite;
        return null;
    }

    public static List<GameObject> GetAllResourcesGameobjects(string path)
    {
        return Resources.LoadAll<GameObject>(path).ToList();
    }

    public static List<Sprite> GetAllResourcesSprites(string path)
    {
        return Resources.LoadAll<Sprite>(path).ToList();
    }

    public static GameObject GetAssetResource(string assetPath)
    {
        return Resources.Load(assetPath) as GameObject;
    }

    public static GameObject GetUnitPrefab(string unitName)
    {
        return GetAssetResource(Constants.ALLY_UNITS_PREFABS_FOLDER_PATH + unitName);
    }
}
