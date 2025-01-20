using UnityEngine;

public abstract class StateBase
{

    protected StateMachine machine;
    public abstract void OnEntered();
    public abstract void OnExited();
    public abstract void Update();

    //"confort" :
    protected Transform transform => machine.transform;

    public StateBase(StateMachine sm)
    {
        machine = sm;
    }

    public void transitionTo(StateBase nextState)
    {
        machine.transitionTo(nextState);
    }


    

}