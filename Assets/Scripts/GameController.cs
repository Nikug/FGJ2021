using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState {
        MainMenu,
        Game,
        GameOver

    }
    public int someNumber = 0;

    public GameState gameState = GameState.Game; 
    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameController");
        if(objects.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Not sure if this structure is necessary
        // Can be removed if not needed
        if(gameState == GameState.Game) {

        } else if (gameState == GameState.MainMenu) {

        } else if (gameState == GameState.GameOver) {

        }
    }

    public void StartGame() {
        this.gameState = GameState.Game;
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "MainMenu") {
            SceneManager.LoadScene("GameScene");
        }

        // Spawn players
        // Set options / scores / etc
        // Other initialization
    }

    public void EndGame() {
        this.gameState = GameState.GameOver;

        // Open some menu or something
        // Despawn / stop players from playing
    }
}
