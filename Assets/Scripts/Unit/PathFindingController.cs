using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingController : MonoBehaviour
{
    private Unit thisUnit = null;

    public Tile nextTile = null;

    public bool HasArrived => thisUnit.OccupiedTile == nextTile;

    private void Awake()
    {
        thisUnit = this.gameObject.transform.parent.GetComponent<Unit>();
    }

    private void FindNextTile()
    {
        List<Tile> neighbours = thisUnit.OccupiedTile.NeighbourTiles;
        float closestDistance = Mathf.Infinity;
        Tile closestTile = null;

        for (int i = 0; i < neighbours.Count; ++i)
        {
            for (int j = 0; j < neighbours.Count; ++j)
            {
                // finding the closest Tile, that is free, to the unit's Target
                var currDistance = Vector2.Distance(neighbours[j].transform.position,
                                                    thisUnit.Target.GetUnit().OccupiedTile.transform.position);
                if (currDistance <= closestDistance)
                {
                    closestDistance = currDistance;
                    closestTile = neighbours[j];
                }
            }
            if (!closestTile.IsOccupied && !closestTile.IsBusy && !closestTile.IsBenchTile)
            {
                nextTile = closestTile;
                break;
            }
            else
            {
                neighbours.Remove(closestTile);
            }
        }
    }

    private bool IsTargetMovingToNeighbourTile()
    {
        foreach (Tile tile in thisUnit.OccupiedTile.NeighbourTiles)
        {
            if (thisUnit.Target.GetUnit().PathFindingController.nextTile == tile)
            {
                return true;
            }
        }
        return false;
    }

    public void Updates()
    {
        if (HasArrived && IsTargetMovingToNeighbourTile() == false)
        {
            nextTile.IsBusy = false;
            FindNextTile();
            nextTile.IsBusy = true;
        }
        else if (HasArrived == false)
        {
            thisUnit.MoveToTile(nextTile);
        }
    }

    public void Start()
    {
        nextTile = thisUnit.OccupiedTile;
    }
}
