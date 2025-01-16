using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{

    public event Action<PlayerReference> OnDead;

    private void OnDestroy()
    {
        OnDead?.Invoke(this);
    }
}
