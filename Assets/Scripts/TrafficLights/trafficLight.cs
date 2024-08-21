using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightState { 
    red,
    green
}

public class trafficLight : MonoBehaviour
{
    [SerializeField]
    Light red, yellow, green;

    public LightState currentStateLight;

    float redTime= 8.0f, yellowTime=1.0f, greenTime= 5.0f;
    void Start()
    {
        SetLightStates(LightState.red);
    }

    // Update is called once per frame
    void Update()
    {
        SetLightStates(currentStateLight);
    }

    public void SetLightStates(LightState newStateLight)
    {
        switch (newStateLight)
        {
            case LightState.red:
                yellow.enabled = true;
                red.enabled = true;
                yellow.enabled = false;
                green.enabled = false;
                break;
            case LightState.green:
                red.enabled = false;
                yellow.enabled = false;
                green.enabled = true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newStateLight), newStateLight, null);
        }
        currentStateLight = newStateLight;
    }

    int AmountCars()
    {
        return 0;
    }
    IEnumerator StateTime(float time, LightState light)
    {
        yield return new WaitForSeconds(time);
        currentStateLight = light;
        StopAllCoroutines();

    }
}
