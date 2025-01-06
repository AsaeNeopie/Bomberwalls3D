using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBloc : MonoBehaviour, IDamageable
{
    public void OnDamageTaken()
    {
        Destroy(gameObject);
    }
}
