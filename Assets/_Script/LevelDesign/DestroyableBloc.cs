using UnityEngine;

public class DestroyableBloc : MonoBehaviour, IDamageable
{
    [SerializeField] Mesh _halfDestroyedMesh;
    bool _halfDestroyed = false;
    public void OnDamageTaken(Vector3 Source)
    {

        PoolManager.Instance.VFXBricksPool.PullObjectFromPool(transform.position).transform.up = (transform.position- Source).normalized + Vector3.up*1.25f;

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
