using UnityEngine;

[System.Serializable]
public struct Target
{
    public Unit unit;
    public float _distance;
    public Vector3 _direction;

    public static float DetectionRange = 15f;
}