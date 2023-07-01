using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float timer = 0;
    private bool isSpawning = false;

    public GameObject pipePrefab;
    public float spawnInterval;
    public float spawnRange;

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnInterval)
        {
            SpawnPipe();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    public void ToggleSpawner()
    {
        isSpawning = !isSpawning;
        if (isSpawning)
        {
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        if (isSpawning)
        {
            Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(-spawnRange, spawnRange), transform.position.z), transform.rotation);
            timer = 0;
        }

    }
}
