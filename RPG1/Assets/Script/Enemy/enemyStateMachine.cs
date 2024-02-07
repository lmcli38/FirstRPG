using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateMachine 
{
    public enemyState currentState { get; private set; }

    public void Initialize(enemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(enemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
