using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoresController : MonoBehaviour
{
    public static TextMeshPro statusText;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public static IEnumerator showStatusText (int forSeconds) {

        /* getPlayerScore() */
        int playerScore = 1;
        /* getPlayerName() */
        string playerName = "Player 1";
        string textToShow = playerName + " now has " + playerScore + " points!";
        setStatusText(textToShow);
        
        yield return new WaitForSeconds(forSeconds);

        removeStatusText();

    }

    private static void removeStatusText () {
        statusText.enabled = false;
        statusText.text = "";
    }

    private static void setStatusText (string textToShow) {
        statusText.text = textToShow;
        statusText.enabled = false;
        

    }
}
