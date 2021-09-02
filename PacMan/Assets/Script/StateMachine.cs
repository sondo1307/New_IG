using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    public State<T> currentState;

    public void ChangeState(State<T> newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Init(State<T> startState)
    {
        currentState = startState;
        currentState.Enter();
    }
}
