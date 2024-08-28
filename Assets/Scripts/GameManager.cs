using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public Canvas canvasStart, canvasSimulation;
    public SystemTrafficLight systemTrafficLight;

    public TMP_InputField IFtrafficAmount;

    public bool isPlay = false;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
                
    }

    public void Play()
    {
        isPlay = true;
        canvasStart.enabled = false;
        canvasSimulation.enabled = true;
        int traffic = Int32.Parse(IFtrafficAmount.text);
        TrafficManagement.SharedInstance.GenerateTraffic(traffic);
        systemTrafficLight.StarTraffic();
    }
}
