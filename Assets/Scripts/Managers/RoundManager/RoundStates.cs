using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStates
{

    public RoundBuyingState BuyingState { get; private set; }
    public RoundFightingState FightingState { get; private set; }

    public RoundStates(RoundManager roundManager, RoundStateController stateController)
    {
        BuyingState = new RoundBuyingState(roundManager, stateController, RoundState.State.Buying);
        FightingState = new RoundFightingState(roundManager, stateController, RoundState.State.Fighting);
    }
}
