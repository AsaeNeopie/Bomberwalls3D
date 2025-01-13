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
    

    void FindAndGoToNewSafeTile()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEntered()
    {
        //machine.Sensor.OnAreaSafeAgain += 
        FindAndGoToNewSafeTile();
        machine.Sensor.OnNewTickingBombDetectedNearby += FindAndGoToNewSafeTile; 
    }

    public override void OnExited()
    {
        machine.Sensor.OnNewTickingBombDetectedNearby -= FindAndGoToNewSafeTile;
    }

    public override void Update()
    {
    }



}
