using UnityEngine;

public class State_ChasingPlayer : StateBase
{
    float lastBombDropTime;
    const float MinimumDelayBetweenBombDrops = .5f;
    public State_ChasingPlayer(StateMachine sm) : base(sm)
    {
    }

    void updateTarget()
    {
        Controller.StartFollowingTarget(Sensor.NearestPlayer.transform);
    }

    public override void OnEntered()
    {
        updateTarget();
        Sensor.OnNearestPlayerChanged+=updateTarget;
    }

    public override void OnExited()
    {
        Sensor.OnNearestPlayerChanged -= updateTarget;
        Controller.StopFollowingTarget();
    }

    public override void Update()
    {
        if (Controller.TargetToFollow == null) { updateTarget(); return; }
        if ((Controller.TargetToFollow.position-transform.position).sqrMagnitude< machine.Sensor.TickingBombDangerRadius* machine.Sensor.TickingBombDangerRadius *0.5f 
            && Time.time- lastBombDropTime> MinimumDelayBetweenBombDrops)
        {
            Controller.TryToDropBomb();
        }
    }


}