using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawn : MonoBehaviour
{
    public GameObject pipes;
    public float spawnYRandom;
    public float timeToSpawn;

    private float SpawnY;
    private float spawnCounter;
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;

        if(spawnCounter <= 0)
        {
            SpawnY = Random.Range(-spawnYRandom, spawnYRandom);
            Instantiate(pipes, new Vector3(transform.position.x, SpawnY, 0), Quaternion.identity);
            spawnCounter = timeToSpawn;
        }

        
    }
}
