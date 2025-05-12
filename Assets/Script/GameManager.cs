using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject mainMenuUI;
    public GameObject gameOverUI;
    public GameObject player;
    private PlayerController playerController;
    public bool isGameStarted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();

    }

    public void StartGame()
    {
        isGameStarted = true;
        mainMenuUI.SetActive(false);
        playerController.EnablePhysics();
    }
    public void GameOver()
    {
        isGameStarted = false;
        gameOverUI.SetActive(true);
        playerController.DisablePhysics();
    }
}