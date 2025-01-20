using UnityEngine;

public class LookAtCamamera : MonoBehaviour
{
    void Update()
    {
        transform.forward = (transform.position - Camera.main.transform.position).normalized;
    }
}
