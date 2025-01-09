using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] AnimationCurve _timeDilatationIntensityCurve;
    [SerializeField] float TimeDilatationFactor = 0.2f;
    [SerializeField] float TimeDilatationDuration = 0.5f;

    float animStartValue;
    Coroutine coroutine;

    //singleton
    public static TimeManager instance { get; private set ; }

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    IEnumerator DilateTime(float duration)
    {
        animStartValue = Time.timeScale;

        

        float endTime = Time.realtimeSinceStartup + duration;
        while (Time.realtimeSinceStartup < endTime)
        {
            //calculer l'alpha
            float alpha = 1 - (endTime - Time.realtimeSinceStartup) / duration;

            //lerp
            float baseValue = Mathf.Lerp(animStartValue, 1, alpha);
            Time.timeScale = Mathf.Lerp(baseValue, baseValue * TimeDilatationFactor, _timeDilatationIntensityCurve.Evaluate(alpha));

            //attendre la frame suivante
            yield return null;
        }

        Time.timeScale = 1;
    }

    public void PlayTimeDilatationAnimation()
    {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(DilateTime(TimeDilatationDuration));
    }
}
