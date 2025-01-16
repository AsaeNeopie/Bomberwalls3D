using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    PlayerMovement _mvt;
    // Start is called before the first frame update
    void Awake()
    {
        transform.parent.gameObject.TryGetComponent(out _mvt);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = _mvt.Velocity.normalized + Vector3.down * 0.5f;
    }
}
