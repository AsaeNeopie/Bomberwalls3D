using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVisuals : MonoBehaviour
{
    PlayerMovement _mvt;

    [SerializeField] VisualEffect _walkVFX;
    bool _walking;

    [Header("rotation")]
    [SerializeField][Range(0,1f)] float _smoothFactor = .1f;
    [SerializeField] float _tiltIntensity = .1f;

    Vector3 _forward = Vector3.zero;


    // Start is called before the first frame update
    void Awake()
    {
        transform.parent.gameObject.TryGetComponent(out _mvt);
    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        Quaternion q = Quaternion.LookRotation(_mvt.Velocity.normalized + Vector3.down * _mvt.Velocity.magnitude * _tiltIntensity, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Mathf.Pow(_smoothFactor, Time.deltaTime));

        if (_mvt.Velocity.sqrMagnitude > 0.2f)
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
