using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    protected override void Awake()
    {
        base.Awake();

        Type = UnitType.Enemy;

        GameManager.Singleton.UnitManager.EnemyUnits.Add(thisUnit);
    }
}
