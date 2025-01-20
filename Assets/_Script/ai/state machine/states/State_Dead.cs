using UnityEngine;

public class State_Dead : StateBase
{
    public State_Dead(StateMachine sm) : base(sm) { }

    

    public override void OnEntered()
    {
        //Time.timeScale = 0;
        Debug.Log(machine.gameObject.name += " died");
    }

    public override void OnExited()
    {
    }


    public override void Update()
    {
    }
}
