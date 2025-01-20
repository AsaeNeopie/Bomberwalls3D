public class State_CollectingBombs : StateBase
{
    public State_CollectingBombs(StateMachine sm) : base(sm) { }

    void updateTarget()
    {
        machine.Controller.TargetToFollow = machine.Sensor.NearestDroppedBomb;
    }

    public override void OnEntered()
    {
        updateTarget();
        machine.Sensor.OnBombPickedUp += updateTarget;
        machine.Sensor.OnNearestBombPickUpChanged += updateTarget;
    }

    public override void OnExited()
    {
        machine.Sensor.OnBombPickedUp -= updateTarget;
        machine.Sensor.OnNearestBombPickUpChanged -= updateTarget;
    }


    public override void Update()
    {
    }


}
