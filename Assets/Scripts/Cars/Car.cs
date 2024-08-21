using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class car : MonoBehaviour
{
    private float velocity = 2;
    public float detectionDistance = 0.7f;



    RaycastHit hit;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // Detecta obstáculos al frente
        if (!Physics.Raycast(new Vector3(transform.position.x, 0.3f, transform.position.z), transform.forward, detectionDistance))
        {
            Debug.DrawRay(new Vector3(transform.position.x, 0.3f, transform.position.z), transform.forward * detectionDistance, Color.green);
            // Si no hay obstáculos, avanza
            rb.velocity = transform.forward * velocity;

            // Visualiza el rayo en verde (sin impacto)
            
        }
        else
        {
            // Si hay obstáculos, detente
            rb.velocity = Vector3.zero;
            Debug.DrawRay(new Vector3(transform.position.x, 0.3f, transform.position.z), transform.forward * detectionDistance, Color.red);
        }
    }

}
