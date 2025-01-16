using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleVFXs;
using UnityEditor.Rendering;

public class TickingBomb : MonoBehaviour
{
    [SerializeField] float _timeToExplode;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _layerMask;
    PooledObject _asPooledObject;

    void OnInstantiatedByPool()
    {
        TryGetComponent<PooledObject>(out _asPooledObject);
    }

    public void OnPulledFromPool()
    {
        StartCoroutine(StartTicking());
    }

    /// <summary>
    /// Fait des dégats a tout ce qui touche l'explosion
    /// </summary>
    public void Explode()
    {
        PoolManager.Instance.VfxExplosionPool.PullObjectFromPool(transform.position);
        //Détection des objets dans ke rayon de l'explosion
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


}
