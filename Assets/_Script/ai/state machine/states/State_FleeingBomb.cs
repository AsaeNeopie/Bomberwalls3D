using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class State_FleeingBomb : StateBase
{
    private List<TickingBomb> _nearbyBombs = new();
    public State_FleeingBomb(StateMachine sm) : base(sm)
    {
    }
    

    public override void OnEntered()
    {
        
    }

    public override void OnExited()
    {
        
    }

    public override void Update()
    {
    }



}
