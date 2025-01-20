using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource s;
    public void Play()
    {
        s.m_DefaultVelocity = Random.insideUnitSphere;
        s.GenerateImpulseWithForce(0.23f);
    }
}
