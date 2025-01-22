using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonJuice : MonoBehaviour
{
    public float Radius = 35f/1920f;
    public float MaxStrength = .13f;
    public float Exponent = .5f;
    Vector2 _basePose;
    RectTransform _rectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent(out _rectTransform);
        _basePose = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float alpha = Mathf.Abs( new Rect(_basePose, _rectTransform.rect.size).DistanceToPoint(Mouse.current.position.value) )/ 1920f / Radius;
        transform.position = Vector3.Lerp(Mouse.current.position.value, _basePose, 1f-Mathf.Clamp01(1f-Mathf.Pow(alpha, Exponent))* MaxStrength);
    }


}
