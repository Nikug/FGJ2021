using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuInputListener : MonoBehaviour
{
    // Start is called before the first frame update

    public List<TextMeshPro> playerStatusPrompts;
    //public List<string> playerAction1Buttons;
    public List<KeyCode> playerKeyCodes;

    private int index;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        index = 0;
        foreach (KeyCode buttonKey in playerKeyCodes) {
            if (Input.GetKeyDown(buttonKey)){
                
                /* spawnSucces = Spawner.spawn(index) */

                bool spawnSuccess = true;
                if ( spawnSuccess ) {
                    changeStatusText(index);
                }
                index++;
            }
        }
    }
    void changeStatusText(int index) {
        playerStatusPrompts[index].text = "Player " + (index+1) + " is ready!";
    }
}
