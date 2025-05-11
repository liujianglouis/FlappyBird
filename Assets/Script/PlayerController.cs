using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    private bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameStarted)
            return;
        if (!hasStarted)
        {
            hasStarted = true;
            rb.simulated = true;
        }
            
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
