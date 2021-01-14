using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineCube : MonoBehaviour
{
    public StateMachineController stateMachine;

    private void Start()
    {
        stateMachine.AwakeMachine(this);
    }

    private void Update()
    {
        stateMachine.UpdateState();
    }

    public void ChangeState(int ind)
    {
        stateMachine.GoTo(stateMachine.GetStateByIndex(ind));
    }


}
