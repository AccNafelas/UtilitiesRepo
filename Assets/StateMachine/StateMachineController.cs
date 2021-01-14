using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachineController
{
    [HideInInspector]
    public MonoBehaviour baseContainer;

    public bool activeMachine = true;
    public List<StateBase> states = new List<StateBase>();

    [Space]
    public StateBase defaultState;

    [Space]
    [SerializeField]
    private StateBase currentState;
    [SerializeField]
    private int currentStateIndex;

    public void AwakeMachine(MonoBehaviour cont)
    {
        baseContainer = cont;
        foreach (var state in states)
        {
            state.OnStateAwake(this);
        }

        currentState = defaultState;
    }

    public void UpdateState()
    {
        if (!activeMachine) return;

        currentState.OnStateUpdate();
    }

    public void GoTo(StateBase targetState)
    {
        currentState.OnStateExit();
        currentState.enabled = false;
        currentState = targetState;
        currentStateIndex = GetIndexOfState(currentState);
        currentState.enabled = true;
        currentState.OnStateEnter();
    }

    public StateBase GetStateByName(string name)
    {
        for (int i = 0; i < states.Count; i++)
        {
            if (states[i].stateName == name)
                return states[i];
        }
        return null;
    }

    public StateBase GetStateByIndex(int ind)
    {
        return states[ind];
    }

    public int GetIndexOfState(StateBase state)
    {
        for (int i = 0; i < states.Count; i++)
        {
            if (states[i].stateName == state.stateName)
                return i;
        }

        return -1;
    }

}
