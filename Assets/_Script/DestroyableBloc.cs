using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBloc : MonoBehaviour, IDamageable
{
    [SerializeField] Mesh _halfDestroyedMesh;
    bool _halfDestroyed = false;
    public void OnDamageTaken(Vector3 Source)
    {
        if (!_halfDestroyed)
        {
            _halfDestroyed = true;
            GetComponent<MeshFilter>().mesh = _halfDestroyedMesh;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
