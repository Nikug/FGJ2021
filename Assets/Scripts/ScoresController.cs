using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoresController : MonoBehaviour
{
    public List<TextMeshPro> statusText;
    // Start is called before the first frame update

    void Start()
    {
    }

    public void updateStatusText(string playerName, int pointsToAdd)
    {
        Debug.Log(playerName + " " + pointsToAdd);
        int playerScore = 0;

        switch (playerName)
        {
            case "1":
                playerScore = Int32.Parse(statusText[0].text.Substring(9));
                statusText[0].text = "Player 1: " + (playerScore + pointsToAdd).ToString();
                break;
            case "2":
                playerScore = Int32.Parse(statusText[1].text.Substring(9));
                statusText[1].text = "Player 2: " + (playerScore + pointsToAdd).ToString();
                break;
            case "3":
                playerScore = Int32.Parse(statusText[2].text.Substring(9));
                statusText[2].text = "Player 3: " + (playerScore + pointsToAdd).ToString();
                break;
            case "4":
                playerScore = Int32.Parse(statusText[3].text.Substring(9));
                statusText[3].text = "Player 4: " + (playerScore + pointsToAdd).ToString();
                break;
        }
    }
}
