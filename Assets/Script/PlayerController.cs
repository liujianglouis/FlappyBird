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
        if (GameManager.Instance.isGameStarted && !GameManager.Instance.isGameOver)
        {
            if (collision.gameObject.CompareTag("PipeSide"))
            {
                // 撞到水管逻辑
                GameManager.Instance.GameOver();
                SoundManager.Instance.PlayHit(); // 播放撞击音效
                StartCoroutine(FallAfterDelay()); // 开始延迟下坠
            }
            else if (collision.gameObject.CompareTag("Land") || collision.gameObject.CompareTag("PipeTop"))
            {
                // 撞地面逻辑
                
                GameManager.Instance.GameOver();
                SoundManager.Instance.PlayHit(); // 播放撞击音效
            }
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
    private IEnumerator FallAfterDelay()
    {
        rb.velocity = Vector2.zero; // 停住角色
        rb.simulated = false;       // 物理暂时停用，定在空中
        yield return new WaitForSeconds(0.3f); // 停留一小会

        rb.simulated = true;        // 再次启用物理
        SoundManager.Instance.PlayDie(); // 播放下坠死亡音效
    }

    public void PlayerResetGame()
    {
        foreach (var pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            Destroy(pipe);
        }
        transform.position = new Vector3(-0.846f, 0, 0);
        DisablePhysics();
        PlayAnimation();
        rb.velocity = Vector2.zero;
    }

}
