using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingController : MonoBehaviour
{
    public Tile nextTile;

    private void Update()
    {
        FindNextTile();
    }

    private void FindNextTile()
    {
        System.Random r = new System.Random();
        r.Next(0, 5);

        Debug.Log(GameManager.GetGameobjectBehindPoint(this.gameObject.transform.position).name);
    }
}
