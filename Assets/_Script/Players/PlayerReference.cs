using System;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{

    public event Action<PlayerReference> OnDead;

    private void OnDestroy()
    {
        OnDead?.Invoke(this);
    }
}
