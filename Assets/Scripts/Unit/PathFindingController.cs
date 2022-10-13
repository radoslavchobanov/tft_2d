using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingController : MonoBehaviour
{
    private bool _enabled = false;

    public Tile nextTile = null;
    public Unit thisUnit = null;

    public bool HasArrived => thisUnit.OccupiedTile == nextTile;

    private void Awake()
    {
        thisUnit = this.gameObject.transform.parent.GetComponent<Unit>();
    }

    private void FindNextTile()
    {
        System.Random r = new System.Random();
        float closestDistance = Mathf.Infinity;
        Tile closestTile = null;

        for (int i = 0; i < thisUnit.OccupiedTile.NeighbourTiles.Count; ++i)
        {
            for (int j = 0; j < thisUnit.OccupiedTile.NeighbourTiles.Count; ++j)
            {
                // finding the closest Tile, that is free, to the unit's Target
                var currDistance = Vector2.Distance(thisUnit.OccupiedTile.NeighbourTiles[j].transform.position,
                                                thisUnit.Target.GetUnit().OccupiedTile.transform.position);
                if (currDistance <= closestDistance)
                {
                    closestDistance = currDistance;
                    closestTile = thisUnit.OccupiedTile.NeighbourTiles[j];
                }
            }
            if (!closestTile.IsOccupied && !closestTile.IsBusy && !closestTile.IsBenchTile)
            {
                nextTile = closestTile;
                break;
            }
        }
    }

    public void Updates()
    {
        if (HasArrived)
        {
            // check if the Target is moving to some neighbour Tile... if yes, dont do anything
            nextTile.IsBusy = false;
            FindNextTile();
            nextTile.IsBusy = true;
        }
        else
        {
            thisUnit.MoveToTile(nextTile);
        }
    }

    public void Enable()
    {
        _enabled = true;
        nextTile = thisUnit.OccupiedTile;
    }
    public void Disable() => _enabled = false;
}
