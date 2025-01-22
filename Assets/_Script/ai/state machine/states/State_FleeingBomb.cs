using System.Collections.Generic;
using UnityEngine;

public class State_FleeingBomb : StateBase
{
    private List<TickingBomb> _nearbyBombs = new();

    const int SafeTileSearchMaxIterations = 5;

    public State_FleeingBomb(StateMachine sm) : base(sm)
    {
    }

    void FindAndGoToNewSafeTile()
    {
        for(int i = 0; i<SafeTileSearchMaxIterations; i++)
        {
            Vector3 t = (Vector3) (LevelManager.Instance.FreeSpaces.PickRandom().X0Y());
            if (Sensor.IsPointSafe(t))
            {
                Controller.GoTo(t);
                break;
            }
        }
        
    }

    public override void OnEntered()
    {
        //machine.Sensor.OnAreaSafeAgain += 
        FindAndGoToNewSafeTile();
        Sensor.OnNewTickingBombDetectedNearby += FindAndGoToNewSafeTile; 
    }

    public override void OnExited()
    {
        Sensor.OnNewTickingBombDetectedNearby -= FindAndGoToNewSafeTile;
    }

    public override void Update()
    {
        if (!Controller.IsPathValid) { FindAndGoToNewSafeTile(); }

    }



}
