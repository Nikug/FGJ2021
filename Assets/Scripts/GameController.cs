using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum GameState {
        MainMenu,
        Game,
        GameOver

    }
    public int someNumber = 0;

    public GameState gameState = GameState.Game; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameState.Game) {

        } else if (gameState == GameState.MainMenu) {

        } else if (gameState == GameState.GameOver) {

        }
    }
}
