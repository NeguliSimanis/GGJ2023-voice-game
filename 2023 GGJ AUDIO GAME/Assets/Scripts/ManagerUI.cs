using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    Player player;
    [SerializeField]
    TextMeshProUGUI philosopherCountText;

    // GAMEOVER
    [Header("game over menu")]
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] Button restartButton;

    //Main menu
    [Header("MAIN MENU")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] Button startButton;

    [Header("YEAR")]
    [SerializeField] TextMeshProUGUI yearText;
    [SerializeField] TextMeshProUGUI endGameTotalYears;

    void Start()
    {
        player = GameManager.instance.currPlayer;
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(true);
        restartButton.onClick.AddListener(RestartGame);
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        GameManager.instance.StartGame();

    }

    public void RestartGame()
    {
        GameManager.instance.RestartGame();
    }

    public void ShowGameOverScreen()
    {
        gameOverMenu.SetActive(true);
        endGameTotalYears.text = "It lasted for " + GameManager.instance.GetCurrentYear().ToString() + " years";
    }

    public void UpdatePhilosopherCount()
    {
        philosopherCountText.text = GameManager.instance.currPhilosphers.ToString();
    }

    public void UpdateYearText()
    {
        string affix = GameManager.instance.GetCurrentYear() > 0 ? "AD" : "BC";
        yearText.text = GameManager.instance.GetCurrentYear().ToString("#0") + affix;
    }
}

