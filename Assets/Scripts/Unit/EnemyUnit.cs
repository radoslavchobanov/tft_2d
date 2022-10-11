using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    Tile startTile;

    protected override void Awake()
    {
        base.Awake();

        Type = UnitType.Enemy;

        GameManager.Singleton.UnitManager.EnemyUnits.Add(thisUnit);

        GameManager.Singleton.EventManager.GameEvents.BuyRoundStart.AddListener(OnBuyRoundStart);
        
        startTile = MapManager.GetTile(5, 7);
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnBuyRoundStart()
    {
        RoundResetUnit();
        PlaceUnit(startTile);
    }
}
