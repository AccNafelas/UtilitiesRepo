using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    public string stateName;

    protected StateMachineController myStateMachine;
    public virtual void OnStateAwake(StateMachineController SM)
    {
        myStateMachine = SM;
    }

    public virtual void OnStateEnter()
    {
        print("OnStateEnter");
    }

    public virtual void OnStateUpdate()
    {
        print("OnStateUpdate");
    }

    public virtual void OnStateExit()
    {
        print("OnStateExit");
    }
}
