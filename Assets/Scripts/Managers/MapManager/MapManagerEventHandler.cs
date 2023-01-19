using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MapManager
{   
    public void RegisterEvents()
    {
        EventManager.Instance.Register(EventID.AllyUnitSelected, OnAllyUnitSelected);
        EventManager.Instance.Register(EventID.AllyUnitPlaced, OnAllyUnitPlaced);
    }

    private void OnAllyUnitSelected(object args)
    {
        MakeAllyTilesSelectable();
    }

    private void OnAllyUnitPlaced(object args)
    {
        ClearAllySelectableTiles();
    }
}
