using UnityEngine;

public class LookAtCamamera : MonoBehaviour
{
    Transform parent;
    Vector3 offset;
    void Awake()
    {
        parent = transform.parent;
        
        transform.parent = null;
        offset = transform.position-parent.position ;
    }
    void Update()
    {
        if(parent == null) { Destroy(gameObject); return; }
        transform.position = parent.position + offset;
        transform.rotation = Camera.main.transform.rotation;
    }
}
