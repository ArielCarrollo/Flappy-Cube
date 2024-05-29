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

    private PipeSpawner pipeSpawner; // Referencia al script de generaci�n de tuber�as

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
        if (other.gameObject.CompareTag("Pipe")) // Si colisiona con una tuber�a
        {
            Vector3 pipeMiddlePosition = pipeSpawner.GetLastSpawnMiddlePosition(); // Obtener la posici�n media de la tuber�a
            Vector3 playerPosition = transform.position; // Posici�n actual del jugador
            Vector3 pushDirection = (playerPosition - pipeMiddlePosition).normalized; // Calcular la direcci�n del empuje (invertida)
            rb.AddForce(pushDirection * jumpForce, ForceMode.Impulse); // Aplicar una fuerza de empuje al p�jaro
        }
    }

}



