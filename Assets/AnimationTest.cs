using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    Animator _animator;
    TMP_Text _text;
    void Start()
    {
        TryGetComponent(out _animator);
        TryGetComponent(out _text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
