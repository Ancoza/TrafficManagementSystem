using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public enum TrafficDensity
{
    Low,
    Medium,
    High
}
public class TrafficManagement : MonoBehaviour
{
    public static TrafficManagement SharedInstance;

    public TrafficSpawner[] trafficSpawners;

    public int carsToSpawnPerInterval = 3;
    public float spawnInterval = 5f;
    public TrafficDensity trafficDensity = TrafficDensity.Low;

    public TMPro.TextMeshProUGUI A, B, C, D;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
    }

    private void Update()
    {
        A.text = (trafficSpawners[0].carsCounter + trafficSpawners[1].carsCounter).ToString();
        B.text = (trafficSpawners[2].carsCounter + trafficSpawners[3].carsCounter).ToString();
        C.text = (trafficSpawners[4].carsCounter + trafficSpawners[5].carsCounter).ToString();
        D.text = (trafficSpawners[6].carsCounter + trafficSpawners[7].carsCounter).ToString();

    }

    public void GenerateTraffic(int trafficCount)
    {
        StartCoroutine(SpawnCarsCoroutine(trafficCount));
    }

    public int GetSumCars()
    {
        if (GetSumA() > GetSumB()) 
        {
            return 1; 
        }else if(GetSumA() < GetSumB())
        {
            return 2; 
        }
        else
        {
            Debug.Log("son iguales carnal");
            return 0;
        }
    }
    public int GetSumA()
    {
        int sumA = trafficSpawners[0].carsCounter + trafficSpawners[1].carsCounter + trafficSpawners[4].carsCounter + trafficSpawners[5].carsCounter;
        Debug.Log(sumA);   
        return sumA;
    }
    public int GetSumB()
    {
        int sumB = trafficSpawners[2].carsCounter + trafficSpawners[3].carsCounter + trafficSpawners[6].carsCounter + trafficSpawners[7].carsCounter;
        Debug.Log(sumB);
        return sumB;
    }

    IEnumerator SpawnCarsCoroutine(int trafficCount)
    {
        for (int i = 0; i < trafficCount; i++)
        {
            int randomIndex,previousIndex=0;
            do
            {
                randomIndex = UnityEngine.Random.Range(0, trafficSpawners.Length);
            } while (randomIndex == previousIndex); // Repetir hasta que sea diferente

            previousIndex = randomIndex; // Guardar el índice actual para la próxima iteración
            trafficSpawners[randomIndex].SpawnCar();

            yield return new WaitForSeconds(1.5f);
        }
    }
}
