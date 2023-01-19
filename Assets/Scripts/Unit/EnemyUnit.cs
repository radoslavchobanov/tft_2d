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

        GameManager.Instance.UnitManager.EnemyUnits.Add(thisUnit);

        OnBuyRoundStart(new object());
    }

    protected override void Start()
    {
        base.Start();
        
        EventManager.Instance.Register(EventID.BuyRoundStart, OnBuyRoundStart);
    }

    private void OnBuyRoundStart(object args)
    {
        RoundResetUnit();
        startTile = MapManager.GetTile(5, 7);
        PlaceUnit(startTile);
    }
}
