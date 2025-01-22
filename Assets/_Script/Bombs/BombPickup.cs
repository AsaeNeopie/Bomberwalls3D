using System;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
    PooledObject _asPooledObject;
    public static List<BombPickup> Instances = new();
    public void OnInstantiatedByPool()
    {
        TryGetComponent<PooledObject>(out _asPooledObject);
    }

    private void Start()
    {
        if (_asPooledObject == null) Instances.Add(this);
    }
    private void OnDestroy()
    {
        if(_asPooledObject == null) Instances.Remove(this);
    }

    public void OnPulledFromPool()
    {
        Instances.Add(this);
    }
    public void OnPutBackIntoPool()
    {
        Instances.Remove(this);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBombing>(out PlayerBombing player))
        {
            player.PickUpNewBomb();
            if (_asPooledObject != null) _asPooledObject.GoBackIntoPool(); else Destroy(gameObject);
        }
    }
}
