using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawn : MonoBehaviour
{
    public GameObject pipes;
    public float spawnYMin;
    public float spawnYMax;
    public float timeToSpawn;
    private float spawnCounter;

    public ScoreController scoreController;
    // Start is called before the first frame update
    void Start()
    {
        PlayInit();
    }

    // Update is called once per frame
    void Update()
    {
        PipeSpawn();
    }
    public void PlayInit()
    {
        spawnCounter = 0;
    }
    
    private void PipeSpawn()
    {
        if (!GameManager.Instance.isGameStarted)
            return;
        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;
            float SpawnY = Random.Range(spawnYMin, spawnYMax);
            GameObject pipe = Instantiate(pipes, new Vector3(transform.position.x, SpawnY, 0), Quaternion.identity);
        }
    }
}
