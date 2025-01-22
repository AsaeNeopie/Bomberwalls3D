using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    public Transform TargetToFollow { get; private set; }

    [Header("References")]
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] PlayerBombing _bombs;

    [Header("Parameters")]
    [SerializeField][Tooltip("the path to the target will be computed everytime the distance between the navMeshAgent destination and the target exceeds this treshold")]
    float _targetMoveTreshold = 0.3f;

    public bool IsPathValid => _navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete;
    public bool TargetReached => _navMeshAgent.remainingDistance<0.05f; //ok
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

    public void StartFollowingTarget(Transform newTarget)
    {
        TargetToFollow = newTarget;
    }

    public void StopFollowingTarget()
    {
        TargetToFollow = null;
    }

    public void GoTo(Vector3 point)
    {
        StopFollowingTarget();
        _navMeshAgent.SetDestination(point);
    }

    public void TryToDropBomb() => _bombs.TryToDropBomb();
}
