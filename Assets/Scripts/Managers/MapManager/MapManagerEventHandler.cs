using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MapManager
{   
    public void RegisterEvents()
    {
        GameEvents.AllyUnitSelected.AddListener(OnAllyUnitSelected);
        GameEvents.AllyUnitPlaced.AddListener(OnAllyUnitPlaced);
    }

    private void OnAllyUnitSelected(Unit selectedUnit)
    {
        MakeAllyTilesSelectable();
    }

    private void OnAllyUnitPlaced(Unit unit, Tile tile)
    {
        ClearAllySelectableTiles();
    }
}
