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
    public ScoreController scoreController;
    public PipesSpawn pipesSpawn;
    public CameraEffect cameraEffect;
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
        cameraEffect.PlayCameraEffect();
    }

    public void ReturnToMainMenu()
    {
        isGameOver = false;
        gameOverUI.SetActive(false);
        mainMenuUI.SetActive(true);
        scoreUI.SetActive(false);
        playerController.PlayerResetGame();
        scoreController.ResetScore();
        pipesSpawn.PlayInit();
    }
}