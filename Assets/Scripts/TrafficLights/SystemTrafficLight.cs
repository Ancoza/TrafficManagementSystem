using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

public enum ModesTrafficLights
{
    OppositeDirectionsX,
    OppositeDirectionsY
}

public class SystemTrafficLight : MonoBehaviour
{
    public TrafficLight[] trafficLights;
    public int[] amoutCarsByStreet;
    public float timeByMode;

    public bool change;

    public TrafficManagement trafficManagement;

    public GameObject TurnA, TurnC;

    public Zone zone;
    private void Start()
    {
        change = false;
    }

    public void StarTraffic()
    {
        StartCoroutine(SystemTraffic());
    }

    //Traffic Light Modes
    void ModeOppositedirectionsX()
    {

        trafficLights[0].SetLightStates(LightState.green);
        trafficLights[2].SetLightStates(LightState.green);
        trafficLights[1].SetLightStates(LightState.red);
        trafficLights[3].SetLightStates(LightState.red);
        TurnA.SetActive(true);
        TurnC.SetActive(true);
    }
    void ModeOppositedirectionsY()
    {
        trafficLights[0].SetLightStates(LightState.red);
        trafficLights[1].SetLightStates(LightState.green);
        trafficLights[3].SetLightStates(LightState.green);
        TurnA.SetActive(false);
        TurnC.SetActive(false);

    }

    void ModeYellow()
    {
        trafficLights[0].SetLightStates(LightState.yellow);
        trafficLights[2].SetLightStates(LightState.yellow);
        trafficLights[1].SetLightStates(LightState.yellow);
        trafficLights[3].SetLightStates(LightState.yellow);
    }

    IEnumerator SystemTraffic()
    {
        while (true)
        {
            if (trafficManagement.GetSumCars()==1) 
            {
                //Debug.Log("A: " + trafficManagement.GetSumA());
                ModeYellow();
                yield return new WaitForSeconds(1f);
                while (zone.IsCarInside())
                {
                    yield return new WaitForSeconds(1f);
                }
                ModeOppositedirectionsX();
                yield return new WaitForSeconds(5);
            }
            else if(trafficManagement.GetSumCars() == 2)
            {
                //Debug.Log("B :" + trafficManagement.GetSumB());
                ModeYellow();
                yield return new WaitForSeconds(1f);
                while (zone.IsCarInside())
                {
                    yield return new WaitForSeconds(1f);
                }
                ModeOppositedirectionsY();
                yield return new WaitForSeconds(5);
            }
            else
            {
                ModeYellow();
                yield return new WaitForSeconds(2);
            }
            change = true;
        }
    }
}
