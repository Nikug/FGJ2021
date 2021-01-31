using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICOntroller : MonoBehaviour
{
    private GameController gameController;
    public TextMeshProUGUI[] playerTexts;
    public GameObject gameOverText;
    public GameObject UI;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void OpenMenu()
    {
        UI.SetActive(true);
    }

    public void CloseMenu()
    {
        UI.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        gameController.ReturnToMainMenu();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowGameOverText()
    {
        gameOverText.SetActive(true);
    }

    public void HideGameOverText()
    {
        gameOverText.SetActive(false);
    }

    public void updateStatusText(string playerName, int newPoints)
    {
        switch (playerName)
        {
            case "1":
                playerTexts[0].text = "Player 1: " + newPoints.ToString();
                break;
            case "2":
                playerTexts[1].text = "Player 2: " + newPoints.ToString();
                break;
            case "3":
                playerTexts[2].text = "Player 3: " + newPoints.ToString();
                break;
            case "4":
                playerTexts[3].text = "Player 4: " + newPoints.ToString();
                break;
        }
    }
}
