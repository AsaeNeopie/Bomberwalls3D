using UnityEditorInternal;
using UnityEngine;

public abstract class StateBase
{

    protected StateMachine machine;
    public abstract void OnEntered();
    public abstract void OnExited();
    public abstract void Update();

    /// <summary>
    /// renvoie true si il y'a eu une transition de l'etat actuel à un autre.
    /// </summary>
    /// <returns></returns>
    public virtual bool ChangeStateIfBetterStateFound()
    {
        StateBase nextState = FindBestState();
        if(nextState!= this)
        {
            transitionTo(nextState);
            return true;
        }
        return false;
    }

    //"confort" :
    protected Transform transform => machine.transform;
    protected AiController Controller => machine.Controller;
    protected AISensor Sensor => machine.Sensor;

    public StateBase(StateMachine sm)
    {
        machine = sm;
    }

    public void transitionTo(StateBase nextState)
    {
        machine.transitionTo(nextState);
    }


    protected StateBase FindBestState()
    {
        //si il est en danger
        if(Sensor.TickingBombsNearby.Count>0) return machine.S_FleeingBomb;

        //sinon, si il a au moins une bombe et n'est pas loin d'un joueur
        if(Sensor.BombCount > 0 && Sensor.NearestPlayer!=null
            && Sensor.NearestPlayer.transform.position.SqrDistanceTo(transform.position)<Sensor.TickingBombDangerRadius*Sensor.TickingBombDangerRadius *1.5f)
            return machine.S_ChasingPlayer;
        
        return machine.S_CollectingBombs;
    }

}