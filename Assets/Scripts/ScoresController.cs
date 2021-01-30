using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoresController : MonoBehaviour
{
    public List<TextMeshPro> statusText;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void showStatusText (string playerName) {

        /* getPlayerScore() */
        int playerScore = 1;
        /* getPlayerName() */
        string textToShow = playerName + " now has " + playerScore + " points!";
        setStatusText(textToShow);
    }

    private void setStatusText (string textToShow) {
        //statusText.text = textToShow;
        //statusText.enabled = false;
        

    }
}
