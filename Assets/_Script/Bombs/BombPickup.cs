using UnityEngine;

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
            if (_asPooledObject != null) _asPooledObject.GoBackIntoPool(); else Destroy(gameObject);
        }
    }
}
