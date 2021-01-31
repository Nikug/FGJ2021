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

    public void updateStatusText(string playerName, int newPoints)
    {
        Debug.Log(playerName + " " + newPoints);

        switch (playerName)
        {
            case "1":
                statusText[0].text = "Player 1: " + newPoints.ToString();
                break;
            case "2":
                statusText[1].text = "Player 2: " + newPoints.ToString();
                break;
            case "3":
                statusText[2].text = "Player 3: " + newPoints.ToString();
                break;
            case "4":
                statusText[3].text = "Player 4: " + newPoints.ToString();
                break;
        }
    }
}
