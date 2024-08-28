using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed; // Velocidad del coche
    public float minSpeed = 10f;
    public float maxSpeed = 20f; // Velocidad máxima permitida
    public float raycastDistance = 3f; // Distancia del raycast
    public Light[] backLights; // Array de objetos de luz trasera

    public TMPro.TextMeshPro textMeshPro;

    [SerializeField]
    public bool carTurns; // The variable that controls if the car turns or not
    public float turnProbability = 0.5f; // 30% probability that the car will turn

    private bool isStopped = false; // Indica si el coche está detenido
    private Rigidbody rb;

    [SerializeField]
    private float anglerotation;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //speed = SetRandomSpeed();
        IsTurn();
        StartCoroutine(IncrementarVelocidad());
    }
    void Update()
    {
        textMeshPro.text = Random.Range(0.8f, 0.99f).ToString("F7");
        rb.velocity = transform.forward * speed;
        
        // Lanzar el raycast hacia adelante
        RaycastHit hit;
        
        Debug.DrawLine(transform.position, transform.position + transform.forward * raycastDistance, Color.red);
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Car"))
            {
                rb.velocity = Vector3.zero;
            }else if(hit.collider.isTrigger && hit.collider.CompareTag("Player") && carTurns)
            {
                StartCoroutine(RotarObjetoSuavemente(90, 0.7f));
            }
            else if (hit.collider.CompareTag("TrafficLight"))
            {
                //Colidder Trigger and Car turns
                if (hit.collider.gameObject.GetComponent<TrafficLight>().currentStateLight == LightState.green)
                {
                    hit.collider.gameObject.GetComponent<TrafficLight>().LessCars();

                }
                else if (hit.collider.gameObject.GetComponent<TrafficLight>().currentStateLight == LightState.red || hit.collider.gameObject.GetComponent<TrafficLight>().currentStateLight == LightState.yellow)
                {
                    // Si hay colisión, detener el coche y encender las luces traseras
                    isStopped = true;
                    rb.velocity = Vector3.zero;
                    foreach (Light backLight in backLights)
                    {
                        backLight.enabled = true;
                    }
                }
                else
                {
                    isStopped = false;
                }
            }
        }
    }

    public void IsTurn()
    {
        carTurns = (Random.value < turnProbability);
    }

    float SetRandomSpeed(float minSpeed, float maxSpeed)
    {
        speed = Random.Range(minSpeed, maxSpeed);
        return speed;
    }

    IEnumerator RotarObjetoSuavemente(float angulo, float duracion)
    {
        Quaternion rotacionInicial = transform.localRotation;

        Quaternion rotacionFinal = Quaternion.Euler(0, angulo, 0);

        float tiempoTranscurrido = 0f;

        bool valuer = Random.value > 0.5f;
        if (!valuer)
        {
            yield return null;
        }
        else
        {
            while (tiempoTranscurrido < duracion)
            {
                tiempoTranscurrido += Time.deltaTime;
                transform.localRotation = Quaternion.Lerp(rotacionInicial, rotacionFinal, tiempoTranscurrido / duracion);
                yield return null; // Espera al siguiente frame
            }
            transform.localRotation = rotacionFinal;
        }

    }

    IEnumerator IncrementarVelocidad()
    {
        yield return new WaitForSeconds(1f); // Esperar el tiempo especificado
        speed += 4;
        yield return new WaitForSeconds(2f); // Esperar el tiempo especificado
        speed += 4;
    }
}
