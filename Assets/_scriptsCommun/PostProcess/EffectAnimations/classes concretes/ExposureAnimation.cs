using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[Serializable]
public class ExposureAnimation : PostProcessEffectAnimation<ColorAdjustments>
{
    public float offset;
    float startValue;

    float AnimStartValue;

    public AnimationCurve AlphaCurve01;
    public override void OnDestroy()
    {
        try { _component.postExposure.value = startValue; } catch { };
    }

    protected override void ApplyEffect(ColorAdjustments component, float alpha)
    {
        alpha = AlphaCurve01.Evaluate(alpha);
        float v = Mathf.Lerp(AnimStartValue, startValue, alpha);//startValue;//
        component.postExposure.value = Mathf.Lerp(v, v + offset, alpha);
    }

    protected override void OnBeforePlay()
    {
        AnimStartValue = _component.postExposure.value;
    }

    protected override void OnSetUp()
    {
        startValue = _component.postExposure.value;
    }

}