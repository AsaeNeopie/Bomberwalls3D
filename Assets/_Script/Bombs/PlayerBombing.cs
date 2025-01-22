using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBombing : MonoBehaviour
{
    GameObject _bomb;
    public byte BombCount { get; private set; } = 0 ;

    public event Action OnBombPickedUp;
    public event Action OnBombDropped;

    public void PickUpNewBomb()
    {
        BombCount++;
        OnBombPickedUp?.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TryToDropBomb();
        }
    }

    public void TryToDropBomb()
    {
        if (BombCount > 0) 
        {
            BombCount--;
            OnBombDropped?.Invoke();
            PoolManager.Instance.bombPool.PullObjectFromPool(transform.position.round()-Vector3.up * 0.5f);
            Vector2Int v = LevelManager.Instance.FreeSpaces[UnityEngine.Random.Range(0, LevelManager.Instance.FreeSpaces.Count)];
            PoolManager.Instance.pickUpPool.PullObjectFromPool(new Vector3(v.x,0,v.y));
        }
    }
}
