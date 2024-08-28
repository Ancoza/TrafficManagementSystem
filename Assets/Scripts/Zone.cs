using UnityEngine;

public class Zone : MonoBehaviour
{
    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isInside = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isInside = false;
        }
    }

    public bool IsCarInside()
    {
        return isInside;
    }
}
