using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    [SerializeField] private float _base; // the full base value with no buffs ... should not be modified
    [SerializeField] private float _baseBuffed; // the base buffed value - before fight buffs (ex. Race or Class buffs, etc.)
    [SerializeField] private float _current; // the stat value while unit is fighting

    public float Base { get { return _base; } }
    public float BaseBuffed { get { return _baseBuffed; } set { _baseBuffed = value; } }
    public float Current { get { return _current; } set { _current = value; } }

    public bool Initialize()
    {
        if (_base == 0) return false;

        _baseBuffed = _base;
        _current = _base;

        return true;
    }

    public void RoundReset()
    {
        _current = _baseBuffed;
    }
}
