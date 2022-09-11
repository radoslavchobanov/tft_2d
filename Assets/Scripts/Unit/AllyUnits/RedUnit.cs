using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedUnit : Unit
{
    protected override void InitializeUnitStats()
    {
        base.InitializeUnitStats();

        Name = "Red";
        MovementSpeed = 5;
        Type = UnitType.Ally;
    }
}
