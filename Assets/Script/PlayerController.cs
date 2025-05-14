using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private float rotationIntensity;
    [SerializeField] private float maxRotation;
    [SerializeField] private float minRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            SoundManager.Instance.PlayJump();
        }
    }
    private void FixedUpdate()
    {
        RotatePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Instance.isGameStarted && (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Land")))
        {
            SoundManager.Instance.PlayHit();
            GameManager.Instance.GameOver();
        }
    }

    public void EnablePhysics()
    {
        rb.simulated = true;
    }

    public void DisablePhysics()
    {
        rb.simulated = false;
    }

    public void StopAnimation()
    {
        if (animator != null)
        {
            animator.enabled = false;
        }
    }
    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.enabled = true;
        }
    }

    private void RotatePlayer()
    {
        if (!GameManager.Instance.isGameOver)
        {
            float rotateAngle;
            if (rb.velocity.y > 0)
            {
                rotateAngle = rb.velocity.y * rotationIntensity;
            }
            else
            {
                rotateAngle = rb.velocity.y * rotationIntensity * 2;
            }

            rotateAngle = Mathf.Clamp(rotateAngle, minRotation, maxRotation);
            Quaternion targetRotation = Quaternion.Euler(0, 0, rotateAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 20f);
        }
    }
}
