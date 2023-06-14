using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public void EnablingLamp(Light lamp, float powerLamp) {
        lamp.intensity = powerLamp;
    }

    public void ShutDownLamp(Light lamp) {
        lamp.intensity = 0f;
    }

    public void StrobeLamp(Light lamp, float intensityNow, float powerLamp) {
        EnablingLamp(lamp, powerLamp);
        StartCoroutine(ShutDownLampCoroutine(lamp, intensityNow));
    } 

    private IEnumerator ShutDownLampCoroutine(Light lamp, float intensityNow) {
        yield return new WaitForSeconds(0.1f);
        lamp.intensity = intensityNow;
    }
}
