using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatsPanelController : MonoBehaviour
{
    public Text AttackDamageNumber;
    public Text AttackSpeedNumber;
    public Text MovementSpeedNumber;
    public Text AttackRangeNumber;

    private static (bool, UnitStatsPanelController) _active = (false, null);

    public void Toggle(Unit unit)
    {
        if (_active.Item1 == true)
        {
            if (_active.Item2 == this)
            {
                this.gameObject.SetActive(false);
                _active.Item1 = false;
                _active.Item2 = null;
            }
            else
            {
                _active.Item2.gameObject.SetActive(false);
                this.gameObject.SetActive(true);
                _active.Item2 = this;
                UpdateStats(unit);
            }
        }
        else
        {
            this.gameObject.SetActive(true);
            _active.Item1 = true;
            _active.Item2 = this;
            UpdateStats(unit);
        }
    }

    private void UpdateStats(Unit unit)
    {
        AttackDamageNumber.text = unit.AttackDamage.ToString();
        AttackSpeedNumber.text = unit.AttackSpeed.ToString();
        MovementSpeedNumber.text = unit.MovementSpeed.ToString();
        AttackRangeNumber.text = unit.AttackRange.ToString();
    }
}
