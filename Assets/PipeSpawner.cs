using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; 
    public float spawnRate = 2f;
    private float timer = 0f;
    public float pipeSpeed = 2f;
    public float heightOffset = 5f; 
    public float gapSize = 2.5f; 

    private Vector3 lastSpawnPosition; 
    private Vector3 lastSpawnMiddlePosition;
    void Start()
    {
        SpawnPipes(); 
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
        Vector3 topPipePosition = new Vector3(10, spawnYPosition + gapSize / 2, 0); 
        Vector3 bottomPipePosition = new Vector3(10, spawnYPosition - gapSize / 2, 0); 

        GameObject topPipe = Instantiate(pipePrefab, topPipePosition, Quaternion.identity);
        GameObject bottomPipe = Instantiate(pipePrefab, bottomPipePosition, Quaternion.identity);

        lastSpawnPosition = topPipe.transform.position; 
        lastSpawnMiddlePosition = (topPipe.transform.position + bottomPipe.transform.position) / 2f; 
        topPipe.GetComponent<Rigidbody>().velocity = new Vector3(-pipeSpeed, 0, 0);
        bottomPipe.GetComponent<Rigidbody>().velocity = new Vector3(-pipeSpeed, 0, 0); 
    }

    public Vector3 GetLastSpawnMiddlePosition()
    {
        return lastSpawnMiddlePosition;
    }
}








