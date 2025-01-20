using UnityEngine;

public class LookAtCamamera : MonoBehaviour
{
    Transform parent;
    Vector3 offset;
    void Awake()
    {
        parent = transform.parent;
        
        transform.parent = null;
        offset = parent.position - transform.position;
    }
    void Update()
    {
        transform.position = parent.position + offset;
        transform.rotation = Camera.main.transform.rotation;
    }
}
