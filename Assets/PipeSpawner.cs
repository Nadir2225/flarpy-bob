using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float initialSpawnRate = 3f;
    public float spawnRate;  // Dynamic spawn rate
    public float timer = 0;
    public float heightOffset = 9f;
    public LogicManager logic;
    public bool firstSpawn = true;
    public float constantDistanceBetweenPipes = 15f;  // Distance between pipes
    public float minSpawnRate = 0.5f;  // Minimum spawn rate to prevent too fast spawning

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManager>();
        spawnRate = initialSpawnRate;
    }

    void Update()
    {
        if (logic.gameActive && !logic.startingState)
        {
            if (firstSpawn)
            {
                SpawnPipe();
                firstSpawn = false;
            }

            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0;

                // Adjust the spawn rate to maintain constant distance between pipes
                spawnRate = Mathf.Max(constantDistanceBetweenPipes / logic.pipeMoveSpeed, minSpawnRate);
            }
        }
    }

    void SpawnPipe()
    {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
