using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawn : MonoBehaviour
{
    public GameObject pipes;
    public float spawnYMin;
    public float spawnYMax;
    public float timeToSpawn;

    private float SpawnY;
    private float spawnCounter;

    public ScoreController scoreController;
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameStarted)
            return;
        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0)
        {
            SpawnY = Random.Range(spawnYMin, spawnYMax);
            GameObject pipe = Instantiate(pipes, new Vector3(transform.position.x, SpawnY, 0), Quaternion.identity);
            ScoreTrigger trigger = pipe.GetComponentInChildren<ScoreTrigger>();

            if(trigger != null)
            {
                trigger.Init(scoreController);
            }

            
            spawnCounter = timeToSpawn;
        }
    }
}
