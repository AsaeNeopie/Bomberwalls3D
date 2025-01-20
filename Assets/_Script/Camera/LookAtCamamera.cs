using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamamera : MonoBehaviour
{
    void Update()
    {
        transform.forward = (transform.position - Camera.main.transform.position).normalized;
    }
}
