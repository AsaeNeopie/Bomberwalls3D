using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReference : MonoBehaviour
{
    public static List<CharacterReference> Instances = new();

    public event Action<CharacterReference> OnDead;

    private void Start()
    {
        Instances.Add(this);
    }

    private void OnDestroy()
    {
        Instances.Remove(this);
        OnDead?.Invoke(this);
    }
}
