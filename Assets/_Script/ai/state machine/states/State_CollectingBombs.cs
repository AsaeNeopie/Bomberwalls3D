using UnityEngine;
public class State_CollectingBombs : StateBase
{
    public State_CollectingBombs(StateMachine sm) : base(sm) { }

    void updateTarget()
    {
        if(Sensor.NearestBombPickUp!=null) Controller.GoTo(Sensor.NearestBombPickUp.transform.position); else
        {
            Controller.GoTo(LevelManager.Instance.FreeSpaces.PickRandom().X0Y());
        }
    }

    public override void OnEntered()
    {
        updateTarget();
        Sensor.OnBombPickedUp += updateTarget;
        Sensor.OnNearestBombPickUpChanged += updateTarget;
    }

    public override void OnExited()
    {
        Sensor.OnBombPickedUp -= updateTarget;
        Sensor.OnNearestBombPickUpChanged -= updateTarget;
    }


    public override void Update()
    {
        if (Sensor.NearestBombPickUp != null) Debug.DrawLine(transform.position, Sensor.NearestBombPickUp.transform.position);
        else if (Controller.TargetReached) { updateTarget(); }
    }


}
