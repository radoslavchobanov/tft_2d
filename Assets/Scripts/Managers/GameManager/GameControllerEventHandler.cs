using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameController
{
    public void RegisterEvents()
    {
        GameManager.Singleton.EventManager.UIEvents.ChangeGameStateButtonClicked.AddListener(OnChangeGameStateButtonClicked);
    }

    private void OnChangeGameStateButtonClicked()
    {
        // Debug.Log("OnChangeGameStateButtonClicked");

        if (CurrentState == GameState.State.Buying)
        {
            StateController.ChangeState(GameStates.FightingState);
        }
        else if (CurrentState == GameState.State.Fighting)
        {
            StateController.ChangeState(GameStates.BuyingState);
        }
    }
}
