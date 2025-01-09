using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBombing : MonoBehaviour
{
    GameObject _bomb;
    public int BombCount = 1;
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
            PoolManager.Instance.bombPool.PullObjectFromPool(transform.position.round());       
        }
    }
}
