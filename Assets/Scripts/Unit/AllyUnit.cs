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

        EventManager.Instance.Invoke(EventID.AllyUnitInstantiated, this);
    }
}
