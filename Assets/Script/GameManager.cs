using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject mainMenuUI;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public GameObject player;
    private PlayerController playerController;
    public bool isGameStarted = false;
    public bool isGameOver;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();

    }

    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            ReturnToMainMenu();
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        mainMenuUI.SetActive(false);
        scoreUI.SetActive(true);
        playerController.EnablePhysics();
    }
    public void GameOver()
    {
        isGameOver = true;
        isGameStarted = false;
        gameOverUI.SetActive(true);
        playerController.StopAnimation();
        CameraShake.Instance.Shake();
        CameraFlashPanel.Instance.Flash();
    }

    public void ReturnToMainMenu()
    {
        isGameOver = false;
        gameOverUI.SetActive(false);
        mainMenuUI.SetActive(true);
        scoreUI.SetActive(false);
        ResetGame();
    }

    void ResetGame()
    {
        foreach (var pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            Destroy(pipe);
        }
        player.transform.position = new Vector3(-0.846f, 0, 0);
        playerController.DisablePhysics();
        playerController.PlayAnimation();
    }
}