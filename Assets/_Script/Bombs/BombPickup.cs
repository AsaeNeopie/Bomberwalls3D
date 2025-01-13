using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BombPickup : MonoBehaviour
{
    PooledObject _asPooledObject;
    public void OnInstantiatedByPool()
    {
        TryGetComponent<PooledObject>(out _asPooledObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBombing>(out PlayerBombing player))
        {
            player.PickUpNewBomb();
            _asPooledObject.GoBackIntoPool();
        }
    }
}
