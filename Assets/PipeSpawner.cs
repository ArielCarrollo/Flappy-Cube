using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Prefab de la tuber�a
    public float spawnRate = 2f; // Frecuencia de aparici�n
    private float timer = 0f;
    public float pipeSpeed = 2f; // Velocidad de movimiento de la tuber�a
    public float heightOffset = 5f; // Rango de altura del spawn
    public float gapSize = 2.5f; // Tama�o del espacio entre las tuber�as

    private Vector3 lastSpawnPosition; // Posici�n de la �ltima tuber�a spawneda
    private Vector3 lastSpawnMiddlePosition; // Posici�n media de la �ltima tuber�a spawneda

    void Start()
    {
        SpawnPipes(); // Spawnear una tuber�a al inicio
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
        Vector3 topPipePosition = new Vector3(10, spawnYPosition + gapSize / 2, 0); // Posici�n de la tuber�a superior
        Vector3 bottomPipePosition = new Vector3(10, spawnYPosition - gapSize / 2, 0); // Posici�n de la tuber�a inferior

        GameObject topPipe = Instantiate(pipePrefab, topPipePosition, Quaternion.identity);
        GameObject bottomPipe = Instantiate(pipePrefab, bottomPipePosition, Quaternion.identity);

        lastSpawnPosition = topPipe.transform.position; // Guardar la posici�n de la �ltima tuber�a spawneda
        lastSpawnMiddlePosition = (topPipe.transform.position + bottomPipe.transform.position) / 2f; // Calcular la posici�n media
        topPipe.GetComponent<Rigidbody>().velocity = new Vector3(-pipeSpeed, 0, 0); // Mover la tuber�a superior hacia la izquierda
        bottomPipe.GetComponent<Rigidbody>().velocity = new Vector3(-pipeSpeed, 0, 0); // Mover la tuber�a inferior hacia la izquierda
    }

    public Vector3 GetLastSpawnMiddlePosition()
    {
        return lastSpawnMiddlePosition; // Obtener la posici�n media de la �ltima tuber�a spawneda
    }
}








