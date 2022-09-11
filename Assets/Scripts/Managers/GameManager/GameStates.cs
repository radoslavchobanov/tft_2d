using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates
{
    public GamePlayState PlayState { get; private set; }
    public GamePauseState PauseStates { get; private set; }

    public GameStates(GameController gameController, GameStateController stateController)
    {
        PlayState = new GamePlayState(gameController, stateController, GameState.State.Play);
        PauseStates = new GamePauseState(gameController, stateController, GameState.State.Pause);
    }
}
