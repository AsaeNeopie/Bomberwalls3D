using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothDamp : MonoBehaviour
{
    public Transform Target;
    [SerializeField] float _smoothTime;
    Vector3 vel;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.position,ref vel,_smoothTime);
    }
}
