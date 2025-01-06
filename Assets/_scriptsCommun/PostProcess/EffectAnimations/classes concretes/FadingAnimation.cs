using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[Serializable]
public class FadingEffect : PostProcessEffectAnimation<ColorAdjustments>
{
    Color startValue;

    Color AnimStartValue;

    public AnimationCurve AlphaCurve01;
    public override void OnDestroy()
    {
        try { _component.colorFilter.value = startValue; } catch { };
    }

    protected override void ApplyEffect(ColorAdjustments component, float alpha)
    {
        alpha = AlphaCurve01.Evaluate(alpha);
        Debug.Log("taiiiin");

        //Color v = Color.Lerp(AnimStartValue, startValue, alpha);
        component.colorFilter.value = Color.Lerp(AnimStartValue, Color.black, alpha);
    }

    protected override void OnBeforePlay()
    {
        Debug.Log("puuu");
        AnimStartValue = _component.colorFilter.value;
    }

    protected override void OnSetUp()
    {
        startValue = _component.colorFilter.value;
    }

}