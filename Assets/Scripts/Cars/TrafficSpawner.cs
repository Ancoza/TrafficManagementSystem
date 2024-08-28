using UnityEngine;
using System.Collections;

public class TrafficSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public float minSpacing = 10f;
    public float maxSpacing = 20f;
    public int carsToSpawnPerInterval = 3;
    public float spawnInterval = 5f;
    public TrafficDensity trafficDensity = TrafficDensity.Low;

    public int carsCounter = 0;
    private Vector3 position;

    void Awake()
    {
        //Prevents models from appearing in the wrong position
        position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            carsCounter--;
        }
    }

    public void SpawnCar()
    {
        //Select random car
        int randomIndex = Random.Range(0, carPrefabs.Length);
        GameObject carPrefab = carPrefabs[randomIndex];
        carsCounter++;

        GameObject newCar = Instantiate(carPrefab, position, transform.rotation);
        newCar.transform.parent = transform;
    }
    void ChangeTrafficDensity()
    {
        if (trafficDensity == TrafficDensity.Low)
        {
            spawnInterval = 5;
        }else if (trafficDensity == TrafficDensity.Medium)
        {
            spawnInterval = 3;
        }
        else if(trafficDensity == TrafficDensity.High)
        {
            spawnInterval = 1;
        }
    }
}