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
    public int maxPlayers = 4;

    public GameObject player;
    private int playerAmount = 0;
    private List<GameObject> players;

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
        if(scene.name != "GameScene") {
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

    public void ReturnToMainMenu() {
        this.gameState = GameState.MainMenu;
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name != "MainMenu") {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public bool addPlayer(int index) {
        
        /* Check if we can make more players etc .. */
        if (index > maxPlayers) {
            return false;
        }

        /* Instantiate a new player */
        GameObject newPlayer = Instantiate(player);

        /* Change player properties */
        newPlayer.name = "Player " + (index+1);

        /* Add player */
        players[index] = newPlayer;
        return true;
    }
}
