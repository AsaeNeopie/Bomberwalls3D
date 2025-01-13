using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class State_ChasingPlayer : StateBase
{
    float lastBombDropTime;
    const float MinimumDelayBetweenBombDrops = .5f;
    public State_ChasingPlayer(StateMachine sm) : base(sm)
    {
    }

    void updateTarget()
    {
        machine.Controller.TargetToFollow = machine.Sensor.NearestPlayer;
    }

    public override void OnEntered()
    {
        machine.Sensor.OnNearestPlayerChanged+=updateTarget;
    }

    public override void OnExited()
    {
        machine.Sensor.OnNearestPlayerChanged -= updateTarget;
    }

    public override void Update()
    {
        if ((machine.Controller.TargetToFollow.position-transform.position).sqrMagnitude< machine.Sensor.TickingBombDangerRadius* machine.Sensor.TickingBombDangerRadius *0.5f 
            && Time.time- lastBombDropTime> MinimumDelayBetweenBombDrops)
        {
            machine.Controller.TryToDropBomb();
        }
    }


}