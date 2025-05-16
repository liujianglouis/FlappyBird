using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("游戏管理器实例")]
    public static GameManager Instance;

    [Header("UI")]
    [Header("主菜单UI")]
    public GameObject mainMenuUI;
    [Header("游戏结束UI")]
    public GameObject gameOverUI;
    [Header("计分器UI")]
    public GameObject scoreUI;

    [Header("脚本引用")]
    [Tooltip("UI管理器")]
    public UIManager uiManager;
    [Tooltip("角色控制器")]
    public PlayerController playerController;
    [Tooltip("分数控制器")]
    public ScoreController scoreController;
    [Tooltip("管道生成器")]
    public PipesSpawn pipesSpawn;
    [Tooltip("摄像机效果管理器")]
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