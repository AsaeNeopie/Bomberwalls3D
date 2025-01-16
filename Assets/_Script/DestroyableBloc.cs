using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBloc : MonoBehaviour, IDamageable
{
    public void OnDamageTaken(Vector3 Source)
    {
        Destroy(gameObject);
    }
}
