using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnit : Unit
{
    protected override void Awake()
    {
        base.Awake();

        Type = UnitType.Ally;
    }

    protected override void Start()
    {
        base.Start();

        GameManager.Singleton.EventManager.GameEvents.AllyUnitInstantiated.Invoke(this);
    }
}
