using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ChasingPlayer : StateBase
{
    public State_ChasingPlayer(StateMachine sm) : base(sm)
    {
    }



    public override void OnEntered()
    {


    }

    public override void OnExited()
    {


    }

    public override void Update()
    {
    }

    /// <summary>
    /// trouve le noeud sur lequel se trouve le joueur et recalcule le chemin si il a changé.
    /// </summary>
    void GoToPlayer()
    {

    }

    /// <summary>
    /// a 2 chances sur 3 de placer une bombe 
    /// </summary>
    void TryToPlaceBombs()
    {


    }
}