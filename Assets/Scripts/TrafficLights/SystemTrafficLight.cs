using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

public class SystemTrafficLight : MonoBehaviour
{
    public trafficLight trafficLightA, trafficLightB, trafficLightC, trafficLightD;

    public float trafficLightTime;
    public float trafficTime;

    private void Start()
    {
        SetA();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            SetA();
        }
        else if (Input.GetKey(KeyCode.B))
        {
            SetB();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            SetC();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SetD();
        }
        else
        {
            
        }
    }

    void SetA() {
        trafficLightA.SetLightStates(LightState.green);
        trafficLightB.SetLightStates(LightState.red);
        trafficLightC.SetLightStates(LightState.red);
        trafficLightD.SetLightStates(LightState.red);
    }
    void SetB()
    {
        trafficLightA.SetLightStates(LightState.red);
        trafficLightB.SetLightStates(LightState.green);
        trafficLightC.SetLightStates(LightState.red);
        trafficLightD.SetLightStates(LightState.red);
    }

    void SetC()
    {
        trafficLightA.SetLightStates(LightState.red);
        trafficLightB.SetLightStates(LightState.red);
        trafficLightC.SetLightStates(LightState.green);
        trafficLightD.SetLightStates(LightState.red);
    }
    void SetD()
    {
        trafficLightA.SetLightStates(LightState.red);
        trafficLightB.SetLightStates(LightState.red);
        trafficLightC.SetLightStates(LightState.green);
        trafficLightD.SetLightStates(LightState.red);
    }
}
