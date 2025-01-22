using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class PlayerVisuals : MonoBehaviour
{
    PlayerMovement _mvt;
    NavMeshAgent _navMeshAgent;

    [SerializeField] VisualEffect _walkVFX;
    bool _walking;

    [Header("Parameters")]
    [SerializeField] bool _useNavmeshAgentVelocity;
    [Header("rotation")]
    [SerializeField][Range(0,1f)] float _smoothFactor = .1f;
    [SerializeField] float _tiltIntensity = .1f;

    Vector3 _forward = Vector3.zero;



    // Start is called before the first frame update
    void Awake()
    {
        transform.parent.gameObject.TryGetComponent(out _mvt);
        transform.parent.gameObject.TryGetComponent(out _navMeshAgent);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = _useNavmeshAgentVelocity ? _navMeshAgent.velocity : _mvt.Velocity;
        //rotation
        Quaternion q = Quaternion.LookRotation(vel.normalized + Vector3.down * vel.magnitude * _tiltIntensity, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Mathf.Pow(_smoothFactor, Time.deltaTime));

        if (vel.sqrMagnitude > 0.2f)
        {
            if(!_walking) _walkVFX.Play();
            _walking = true;
        }
        else
        {
            if (_walking) _walkVFX.Stop();
            _walking = false;
        }
    }
}
