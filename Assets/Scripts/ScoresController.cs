using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoresController : MonoBehaviour
{
    public TextMeshPro statusText;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public IEnumerator showStatusText (int forSeconds) {

        /* getPlayerScore() */
        int playerScore = 1;
        /* getPlayerName() */
        string playerName = "Player 1";
        string textToShow = playerName + " now has " + playerScore + " points!";
        setStatusText(textToShow);
        
        yield return new WaitForSeconds(forSeconds);

        removeStatusText();

    }

    private void removeStatusText () {
        statusText.enabled = false;
        statusText.text = "";
    }

    private void setStatusText (string textToShow) {
        statusText.text = textToShow;
        statusText.enabled = false;
        

    }
}
