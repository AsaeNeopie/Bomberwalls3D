using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    public Transform TargetToFollow;

    [Header("References")]
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] PlayerBombing _bombs;

    [Header("Parameters")]
    [SerializeField][Tooltip("the path to the target will be computed everytime the distance between the navMeshAgent destination and the target exceeds this treshold")]
    float _targetMoveTreshold = 0.3f;

    private void Update()
    {
        //follow target
        if(
            _navMeshAgent.destination!=null
            && TargetToFollow!=null
            && (_navMeshAgent.destination-TargetToFollow.position).sqrMagnitude > _targetMoveTreshold * _targetMoveTreshold
            )
        {
            _navMeshAgent.SetDestination(TargetToFollow.position);
        }
    }

    public void TryToDropBomb() => _bombs.TryToDropBomb();
}
