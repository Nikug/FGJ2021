using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuInputListener : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController gameController;
    public List<TextMeshPro> playerStatusPrompts;
    //public List<string> playerAction1Buttons;
    public List<string> playerJoinKey;
    public List<string> playerLeaveKey;
    public List<string> joinedPlayers;

    private int index;
    void Start()
    {
        index = 0;
        playerJoinKey = new List<string>();
        playerLeaveKey = new List<string>();
        for(int i = 0; i < 4; i++) {
            playerJoinKey.Add("Joy" + (i +1) + "Action1");
        }
        for(int i = 0; i < 4; i++) {
            playerLeaveKey.Add("Joy" + (i +1) + "Action2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string buttonKey in playerJoinKey) {
            if (Input.GetButtonDown(buttonKey)){
                string name = buttonKey.Substring(3, 1);
                if(!joinedPlayers.Contains(name)) {
                    joinedPlayers.Add(name);
                    changeStatusText(int.Parse(name) - 1, name, true);
                }
                
                gameController.addPlayer(name);

            }
        }

        foreach (string buttonKey in playerLeaveKey) {
            if (Input.GetButtonDown(buttonKey)){
                string name = buttonKey.Substring(3, 1);
                if(joinedPlayers.Contains(name)) {
                    joinedPlayers.Remove(name);
                    gameController.removePlayer(name);
                    changeStatusText(int.Parse(name) - 1, name, false);
                }
                
                /* spawnSucces = Spawner.spawn(index) */

            }
        }
    }
    void changeStatusText(int index, string player, bool joined) {
        if(joined) {
            playerStatusPrompts[index].text = "Player " + player + " is ready!";
        } else {
            playerStatusPrompts[index].text = "Press A to join";
        }
    }
}
