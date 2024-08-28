using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LightState { 
    red,
    yellow,
    green
}

public class TrafficLight : MonoBehaviour
{
    [SerializeField]
    Light red, yellow, green;

    public Image ImgRed, Imgyellow, Imggren;

    public LightState currentStateLight;

    public int amountCars;

    float redTime= 8.0f, yellowTime=1.0f, greenTime= 5.0f;

    private BoxCollider boxCollider;

    public TrafficSpawner tsRight, tsLeft;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SetLightStates(currentStateLight);
        amountCars = tsLeft.carsCounter + tsRight.carsCounter;
    }

    public LightState GetLight()
    {
        return currentStateLight;
    }

    public void LessCars()
    {
        amountCars--;
    }

    public void SetLightStates(LightState newStateLight)
    {
        switch (newStateLight)
        {
            case LightState.red:
                red.enabled = true;
                yellow.enabled = false;
                green.enabled = false;
                
                ImgRed.enabled = true;
                Imggren.enabled = false;
                Imgyellow.enabled = false;
                //boxCollider.enabled = true;

                break;
            case LightState.yellow:
                yellow.enabled = true;
                red.enabled = false;
                green.enabled = false;

                ImgRed.enabled = false;
                Imggren.enabled = false;
                Imgyellow.enabled = true;

                break;
            case LightState.green:
                red.enabled = false;
                yellow.enabled = false;
                green.enabled = true;

                ImgRed.enabled = false;
                Imggren.enabled = true;
                Imgyellow.enabled = false;
                //boxCollider.enabled = false;

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newStateLight), newStateLight, null);
        }
        currentStateLight = newStateLight;
    }

}
