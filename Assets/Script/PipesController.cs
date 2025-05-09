using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    public float pipesMoveSpeed;

    public float destroyPositionX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.right * pipesMoveSpeed * Time.deltaTime;

        if (transform.position.x <= destroyPositionX)
        {
            Destroy(gameObject);
        }
    }
}
