using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RoundManager
{
    public void RegisterEvents()
    {
        EventManager.Instance.Register(EventID.ChangeGameStateButtonClicked, OnChangeGameStateButtonClicked);
    }

    private void OnChangeGameStateButtonClicked(object args)
    {
        // Debug.Log("OnChangeGameStateButtonClicked");

        if (CurrentState == RoundState.State.Buying)
        {
            StateController.ChangeState(RoundStates.FightingState);
        }
        else if (CurrentState == RoundState.State.Fighting)
        {
            StateController.ChangeState(RoundStates.BuyingState);
        }
    }
}
