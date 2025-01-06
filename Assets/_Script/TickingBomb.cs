using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickingBomb : MonoBehaviour
{
    [SerializeField] float _timeToExplode;
    public void Explode()
    {

    }

    IEnumerator StartTicking()
    {
        yield return new WaitForSeconds(_timeToExplode);
    }
}
