using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("游戏管理器实例")]
    public static GameManager Instance;

    [Header("UI")]
    public GameObject mainMenuUI;
    public GameObject gameOverUI;
    public GameObject scoreUI;

    [Header("脚本引用")]
    public UIManager uiManager;
    public PlayerController playerController;
    public ScoreController scoreController;
    public PipesSpawn pipesSpawn;
    public CameraEffectManager cameraEffect;


    [Header("游戏状态")]
    public bool isGameStarted = false;
    public bool isGameOver = false;
    public bool isMainMenu = true;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerController.InitGame();
        pipesSpawn.InitGame();
        uiManager.InitGame();
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
        uiManager.ShowGamingUI();
        playerController.StartGame();
    }
    public void GameOver()
    {
        isGameStarted = false;
        isGameOver = true;
        uiManager.ShowGameOverUI();
        playerController.GameOver();
        cameraEffect.PlayCameraEffect();
    }

    public void ReturnToMainMenu()
    {
        isGameOver = false;
        uiManager.ShowMainMenuUI();
        playerController.InitGame();
        pipesSpawn.InitGame();
        uiManager.InitGame();
    }
}