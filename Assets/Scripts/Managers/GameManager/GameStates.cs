using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates
{
    public GameBuyingState BuyingState { get; private set; }
    public GameFightingState FightingState { get; private set; }

    public GameStates(GameController gameController, GameStateController stateController)
    {
        BuyingState = new GameBuyingState(gameController, stateController, GameState.State.Buying);
        FightingState = new GameFightingState(gameController, stateController, GameState.State.Fighting);
    }
}
