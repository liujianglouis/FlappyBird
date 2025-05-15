using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    public float pipesMoveSpeed;

    public float destroyPositionX;

    // Update is called once per frame
    void Update()
    {
        PipeMove();
        PipeDestroy();
    }

    private void PipeMove()
    {
        if (!GameManager.Instance.isGameStarted)
            return;
        transform.position -= Vector3.right * pipesMoveSpeed * Time.deltaTime;
    }

    private void PipeDestroy()
    {
        if (transform.position.x <= destroyPositionX)
        {
            Destroy(gameObject);
        }
    }
}
