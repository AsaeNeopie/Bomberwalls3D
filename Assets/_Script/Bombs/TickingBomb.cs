using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickingBomb : MonoBehaviour
{
    [SerializeField] float _timeToExplode;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Collider _collider;
    PooledObject _asPooledObject;

    public static List<TickingBomb> Instances = new();

    void OnInstantiatedByPool()
    {
        TryGetComponent<PooledObject>(out _asPooledObject);
        TryGetComponent(out _collider);

    }

    public void OnPulledFromPool()
    {
        _collider.isTrigger = true;

        Instances.Add(this);
        if (LevelManager.Instance.FreeSpaces.Contains(transform.position.XZ().round()))
        {
            LevelManager.Instance.FreeSpaces.Remove(transform.position.XZ().round());
        }

        StartCoroutine(StartTicking());
    }

    public void OnPutBackIntoPool()
    {
        Instances.Remove(this);

        if (!LevelManager.Instance.FreeSpaces.Contains(transform.position.XZ().round()))
        {
            LevelManager.Instance.FreeSpaces.Add(transform.position.XZ().round());
        }
    }

    private void OnDestroy()
    {
        if (Instances.Contains(this))Instances.Remove(this);
    }

    /// <summary>
    /// Fait des d�gats a tout ce qui touche l'explosion
    /// </summary>
    public void Explode()
    {
        PoolManager.Instance.VfxExplosionPool.PullObjectFromPool(transform.position);
        //D�tection des objets dans ke rayon de l'explosion
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius,_layerMask);
        
        foreach (Collider c in hits)
        {
            if (c.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                Vector3 offset = c.transform.position-transform.position;
                if(Physics.Raycast(transform.position,offset,out RaycastHit hit,offset.magnitude) && hit.collider == c)
                {
                    damageable.OnDamageTaken(transform.position);
                }
                //@TODO Raycast
            }
        }

        //Bombe retourne dans la pool
        _asPooledObject.GoBackIntoPool();
    }

    IEnumerator StartTicking()
    {
        yield return new WaitForSeconds(_timeToExplode);
        Explode();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _collider.isTrigger = false;
        }
    }

}
