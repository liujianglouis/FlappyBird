using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject scoreUI;
    public GameObject gameOverUI;
    public ScoreController scoreController;

    public void ShowMainMenuUI()
    {
        mainMenuUI.SetActive(true);
        scoreUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void ShowGamingUI()
    {
        mainMenuUI.SetActive(false);
        scoreUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void InitGame()
    {
        scoreController.InitGame();
    }
}
