using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState2 : StateBase
{
    public MeshRenderer MR;
    public Material statematerial;
    public TextMesh TM;


    private float timer = 0f;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        print(" Entered in state called: " + base.stateName);
        TM.text = base.stateName;
        MR.material = statematerial;
        timer = 0f;
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        print(" Leaving state called: " + base.stateName);
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        print(" Update the state called: " + base.stateName);
        timer += Time.deltaTime;
        TM.text = base.stateName + " T:" + timer;
    }
}
