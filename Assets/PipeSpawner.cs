using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Prefab de la tubería
    public float spawnRate = 2f; // Frecuencia de aparición
    private float timer = 0f;
    public float pipeSpeed = 2f; // Velocidad de movimiento de la tubería
    public float heightOffset = 5f; // Rango de altura del spawn
    public float gapSize = 2.5f; // Tamaño del espacio entre las tuberías

    private Vector3 lastSpawnPosition; // Posición de la última tubería spawneda
    private Vector3 lastSpawnMiddlePosition; // Posición media de la última tubería spawneda

    void Start()
    {
        SpawnPipes(); // Spawnear una tubería al inicio
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipes();
            timer = 0;
        }
    }

    void SpawnPipes()
    {
        float spawnYPosition = Random.Range(-heightOffset, heightOffset);
        Vector3 topPipePosition = new Vector3(10, spawnYPosition + gapSize / 2, 0); // Posición de la tubería superior
        Vector3 bottomPipePosition = new Vector3(10, spawnYPosition - gapSize / 2, 0); // Posición de la tubería inferior

        GameObject topPipe = Instantiate(pipePrefab, topPipePosition, Quaternion.identity);
        GameObject bottomPipe = Instantiate(pipePrefab, bottomPipePosition, Quaternion.identity);

        lastSpawnPosition = topPipe.transform.position; // Guardar la posición de la última tubería spawneda
        lastSpawnMiddlePosition = (topPipe.transform.position + bottomPipe.transform.position) / 2f; // Calcular la posición media
        topPipe.GetComponent<Rigidbody>().velocity = new Vector3(-pipeSpeed, 0, 0); // Mover la tubería superior hacia la izquierda
        bottomPipe.GetComponent<Rigidbody>().velocity = new Vector3(-pipeSpeed, 0, 0); // Mover la tubería inferior hacia la izquierda
    }

    public Vector3 GetLastSpawnMiddlePosition()
    {
        return lastSpawnMiddlePosition; // Obtener la posición media de la última tubería spawneda
    }
}








