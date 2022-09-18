using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UnitController
{
    public void RegisterEvents()
    {
        GameManager.Singleton.EventManager.GameEvents.FightRoundStart.AddListener(OnFightRoundStart);
        GameManager.Singleton.EventManager.GameEvents.BuyRoundStart.AddListener(OnBuyRoundStart);
    }
    private void OnFightRoundStart()
    {
        if (IsOnBench == false) 
            StateController.ChangeState(UnitStates.MoveState);
    }

    private void OnBuyRoundStart()
    {
        StateController.ChangeState(UnitStates.IdleState);
    }
}
