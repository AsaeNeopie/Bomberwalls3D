using UnityEngine;

public class State_Win : StateBase
{
    public State_Win(StateMachine sm) : base(sm) { }


    public override void OnEntered()
    {
        Debug.Log(machine.gameObject.name += " won");
    }

    public override void OnExited()
    {
    }

    

    public override void Update()
    {
    }
}
