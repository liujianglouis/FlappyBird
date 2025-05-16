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
    private void Awake()
    {
        GetComponent();
    }

    // Update is called once per frame
    void Update()
    {
        MonitorInput();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }

    private void GetComponent()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void MonitorInput()
    {
        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();

        }
    }

    private void RotatePlayer()
    {

        if (GameManager.Instance.isGameOver)
            return;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverDetection(collision);
    }

    public void StartGame()
    {
        rb.simulated = true;
    }

    public void GameOver()
    {
        animator.enabled = false;
    }

    
    

    public void InitGame()
    {
        transform.position = new Vector3(-0.846f, 0, 0);
        rb.simulated = false;
        animator.enabled = true;
        rb.velocity = Vector2.zero;
    }


    
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        SoundManager.Instance.PlayJump();
    }
    private void GameOverDetection(Collision2D collision)
    {
        if (GameManager.Instance.isGameStarted && !GameManager.Instance.isGameOver)
        {
            if (collision.gameObject.CompareTag("PipeSide"))
            {
                GameManager.Instance.GameOver();
                SoundManager.Instance.PlayHit(); 
                StartCoroutine(FallAfterDelay()); 
            }
            else if (collision.gameObject.CompareTag("Land") || collision.gameObject.CompareTag("PipeTop"))
            {
                GameManager.Instance.GameOver();
                SoundManager.Instance.PlayHit(); 
            }
        }
    }

    private IEnumerator FallAfterDelay()
    {
        rb.velocity = Vector2.zero; 
        rb.simulated = false;       
        yield return new WaitForSeconds(0.3f); 

        rb.simulated = true;        
        SoundManager.Instance.PlayDie(); 
    }
}
