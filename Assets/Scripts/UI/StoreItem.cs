using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoreItem
{
    [SerializeField] protected string _unitName;
    [SerializeField] protected Sprite _unitSprite; // decide if this should be string spriteName
    [SerializeField] protected UnityAction _unitActionOnClick;

    public string UnitName { get { return _unitName; } }
    public Sprite UnitSprite { get { return _unitSprite; } }
    public UnityAction UnitActionOnClick { get { return _unitActionOnClick; } }

    protected GameObject UnitPrefab => ResourceManager.GetUnitPrefab(UnitName);

    public StoreItem(string unitName)
    {
        // Debug.Log("Create Store Item for: " + UnitName);

        _unitName = unitName;
        _unitSprite = ResourceManager.GetUnitSprite(unitName);

        _unitActionOnClick = OnStoreItemClick;
    }

    public void OnStoreItemClick()
    {
        // Debug.Log("StoreItem clicked for: " + UnitName);

        UnitPrefab.TryGetComponent<Unit>(out Unit unit);
        if (unit.CanBeSpawnedOnBench())
        {
            EventManager.Instance.Invoke(EventID.AllyUnitBought, unit);
        }
        else
        {
            Debug.LogWarning("No free Bench Tiles to spawn Unit");
            // not been able to buy this unit
        }
    }
}
