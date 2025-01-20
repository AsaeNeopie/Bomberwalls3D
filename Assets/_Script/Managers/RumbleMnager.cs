using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleMnager : MonoBehaviour
{
    public static RumbleMnager instance;
    //private Gamepad pad;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    public void RumblePulse(Gamepad pad, float lowFrenquency, float highFrequency, float duration)
    {
        pad = Gamepad.current;

        if(pad != null)
        {
            pad.SetMotorSpeeds(lowFrenquency, highFrequency);
        }    
        StartCoroutine(StopRumble(duration, pad));
    }

    private IEnumerator StopRumble(float duration, Gamepad pad)
    {
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        pad.SetMotorSpeeds(0f, 0f);
    }
}
