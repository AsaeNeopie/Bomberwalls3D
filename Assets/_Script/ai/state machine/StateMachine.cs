using System.Collections;
using UnityEngine;

/// <summary>
/// la machine à état du bot.
/// </summary>
public class StateMachine : MonoBehaviour
{

    StateBase currentState;

    //states
    public State_ChasingPlayer S_ChasingPlayer;
    public State_FleeingBomb S_FleeingBomb;
    public State_CollectingBombs S_CollectingBombs;
    public State_Dead S_Dead;
    public State_Win S_Win;

    //references
    public AISensor Sensor;
    public AiController Controller;


    private void Awake()
    {
        InitStates();
    }

    private IEnumerator Start()
    {
        yield return 0 ;
        GameManager.Instance.OnGameStart+= () => transitionTo(S_CollectingBombs);
    }

    /// <summary>
    /// transitionne vers un autre état
    /// </summary>
    /// <param name="to"></param>
    public void transitionTo(StateBase to)
    {
        if(currentState!=null) currentState.OnExited();
        currentState = to;
        currentState.OnEntered();
        //print(currentState.GetType().ToString());
    }

    private void Update()
    {
        if (currentState != null)
        {
            if(!currentState.ChangeStateIfBetterStateFound()) 
            currentState.Update();
        }
    }

    /// <summary>
    /// instancie tous les etats
    /// </summary>
    void InitStates()
    {
         S_ChasingPlayer = new(this);
         S_FleeingBomb = new(this);
         S_CollectingBombs = new(this);
         S_Dead = new(this);
         S_Win = new(this);
    }
}
