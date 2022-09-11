using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UnitController
{
    private GameEvents GameEvents => GameManager.Singleton.EventManager.GameEvents;
    public void RegisterEvents()
    {
        GameEvents.FightRoundStart.AddListener(OnFightRoundStart);
        GameEvents.BuyRoundStart.AddListener(OnBuyRoundStart);
    }
    private void OnFightRoundStart()
    {
        StateController.ChangeState(UnitStates.MoveState);
    }

    private void OnBuyRoundStart()
    {
        StateController.ChangeState(UnitStates.IdleState);
    }
}
