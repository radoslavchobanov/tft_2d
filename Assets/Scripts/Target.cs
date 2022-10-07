using UnityEngine;

[System.Serializable]
public class Target
{
    [SerializeField] private Unit _unit;
    [SerializeField] private float _distance;
    private Vector3 _direction;

    public static float DetectionRange = 15f;

    public Target()
    {
        this._unit = null;
        this._distance = Mathf.Infinity;
        this._direction = Vector3.zero;
    }
    public Target(Unit targetUnit, float distanceToTarget, Vector3 directionToTarget)
    {
        this._unit = targetUnit;
        this._distance = distanceToTarget;
        this._direction = directionToTarget;
    }

    public Unit GetUnit() => this._unit;
    public void SetUnit(Unit unit) => this._unit = unit;
    public float GetDistance() => this._distance;
    public void SetDistance(float distance) => this._distance = distance;
    public Vector3 GetDirection() => this._direction;
    public void SetDirection(Vector3 direction) => this._direction = direction;

    public void Remove()
    {
        this._unit = null;
        this._distance = Mathf.Infinity;
        this._direction = Vector3.zero;
    }
}