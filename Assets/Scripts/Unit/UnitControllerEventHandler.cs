using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UnitController
{
    public void RegisterEvents()
    {
        EventManager.Instance.Register(EventID.FightRoundStart, OnFightRoundStart);
        EventManager.Instance.Register(EventID.BuyRoundStart, OnBuyRoundStart);
    }
    private void OnFightRoundStart(object args)
    {
        // if (IsOnBench == false)
            StateController.ChangeState(UnitStates.MoveState);
    }

    private void OnBuyRoundStart(object args)
    {
        StateController.ChangeState(UnitStates.IdleState);
    }
}
