using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoreManager : MonoBehaviour
{
    // list with store items for all the units ... shouldnt be changed, only filled with items in Awake() - CreateStoreItems()
    private static readonly List<StoreItem> StoreItems = new();
    private List<StoreItem> _currentlyGeneratedItems = new();
    public static UnityEvent<List<StoreItem>> OnGeneratedItems = new();

    private void Awake()
    {
        CreateStoreItems();
    }

    private void Start()
    {
        RefreshStore();
    }

    private static void CreateStoreItems()
    {
        foreach (var obj in ResourceManager.AllAllyUnitPrefabs)
        {
            if (obj == null)
            {
                Debug.Log("HERERERERR");
                return;
            }
            StoreItem storeItem = new StoreItem(obj.name);
            StoreItems.Add(storeItem);
        }
    }

    private List<StoreItem> ShuffleStoreItems()
    {
        var shuffledStoreItems = StoreItems;

        // shuffle with given rule
        // in order to have some units better chance to occur

        // !! For now this shuffle does the work
        System.Random r = new System.Random();
        int randNum = 0;
        for (int i = 0; i < StoreItems.Count; ++i)
        {
            randNum = r.Next(0, 6);
            var temp = shuffledStoreItems[i];
            shuffledStoreItems[i] = shuffledStoreItems[randNum];
            shuffledStoreItems[randNum] = temp;
        }

        return shuffledStoreItems;
    }

    public void GenerateStoreItems()
    {
        _currentlyGeneratedItems.Clear();
        var shuffledItems = ShuffleStoreItems();

        var count = shuffledItems.Count < 6 ? shuffledItems.Count : 6;
        for (int i = 0; i < count; ++i)
        {
            _currentlyGeneratedItems.Add(shuffledItems[i]);
        }
    }

    public void RefreshStore()
    {
        GenerateStoreItems();
        OnGeneratedItems.Invoke(_currentlyGeneratedItems);
    }
}
