   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using System;
using System.Threading.Tasks;
using static PostProcessController;
using Unity.VisualScripting;
using System.ComponentModel;


public class PostProcessController : MonoBehaviour
{
    [Header("references")]
    [SerializeField] VolumeProfile mVolumeProfile;

    [Header("Effects")]
    public ExposureAnimation E_ExposureFlash = new();
    public ScreenDistortionAnimation E_ScreenDistortion = new();
    public FadingEffect FadeIn = new();
    public FadingEffect FadeOut = new();

    //singleton
    public static PostProcessController instance { get;private set; }

    //animation management
    public Dictionary<Type, Coroutine> effectsCoroutines = new();

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    void Start()
    {
        E_ExposureFlash.SetUp(mVolumeProfile);
        E_ScreenDistortion.SetUp(mVolumeProfile);
        FadeIn.SetUp(mVolumeProfile);
        FadeOut.SetUp(mVolumeProfile);

        //FadeIn.play(true);

    }

    private void OnDestroy()
    {
        E_ExposureFlash.OnDestroy();
        E_ScreenDistortion.OnDestroy();
        FadeIn.OnDestroy();
        FadeOut.OnDestroy();
    }
    

}