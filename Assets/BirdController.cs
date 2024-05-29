using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f; 
    public float rotationSpeed = 5f; 
    public float jumpCooldown = 0.2f; 

    private Rigidbody rb;
    private float lastJumpTime;

    private PipeSpawner pipeSpawner; // Referencia al script de generación de tuberías

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pipeSpawner = FindObjectOfType<PipeSpawner>(); // Encontrar el script PipeSpawner3D en la escena
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastJumpTime > jumpCooldown)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            lastJumpTime = Time.time;
        }

        
        Quaternion targetRotation = Quaternion.identity;
        if (rb.velocity.y < 0) 
        {
            targetRotation = Quaternion.Euler(0f, 0f, -30f); 
        }
        else 
        {
            targetRotation = Quaternion.Euler(0f, 0f, 30f);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe")) // Si colisiona con una tubería
        {
            Vector3 pipeMiddlePosition = pipeSpawner.GetLastSpawnMiddlePosition(); // Obtener la posición media de la tubería
            Vector3 playerPosition = transform.position; // Posición actual del jugador
            Vector3 pushDirection = (playerPosition - pipeMiddlePosition).normalized; // Calcular la dirección del empuje (invertida)
            rb.AddForce(pushDirection * jumpForce, ForceMode.Impulse); // Aplicar una fuerza de empuje al pájaro
        }
    }

}



