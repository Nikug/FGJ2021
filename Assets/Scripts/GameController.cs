using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Game,
        GameOver

    }
    public int maxPlayers = 4;

    public GameObject player;
    private int playerAmount = 0;
    private List<GameObject> players;

    public GameState gameState = GameState.Game;
    private List<Transform> spawnPoints;
    public string spawnPointTag = "PlayerSpawnpoint";
    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameController");
        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        players = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Not sure if this structure is necessary
        // Can be removed if not needed
        if (gameState == GameState.Game)
        {

        }
        else if (gameState == GameState.MainMenu)
        {

        }
        else if (gameState == GameState.GameOver)
        {

        }
    }

    public void StartGame()
    {
        this.gameState = GameState.Game;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "GameScene")
        {
            SceneManager.LoadScene("GameScene");
        }

        spawnPlayers();


        // Set options / scores / etc
        // Other initialization
    }

    public void EndGame()
    {
        this.gameState = GameState.GameOver;

        // Open some menu or something
        // Despawn / stop players from playing
    }

    public void ReturnToMainMenu()
    {
        this.gameState = GameState.MainMenu;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "MainMenu")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public bool addPlayer(string name)
    {
        if (!playerExists(name))
        {
            spawnSinglePlayer(name);

            return true;
        }
        return false;
    }

    public void spawnPlayers()
    {
        foreach (var p in players)
        {
            spawnSinglePlayer(p.GetComponent<PlayerInfo>().playerName);
        }
    }

    private void spawnSinglePlayer(string name)
    {
        var newPlayer = Instantiate(player);
        newPlayer.GetComponent<PlayerInfo>().playerName = name;

        var controller = newPlayer.GetComponent<PlayerMovement>();
        controller.horizontal = "Joy" + name + "Axis1";
        controller.vertical = "Joy" + name + "Axis2";

        var grab = newPlayer.GetComponent<PlayerGrab>();
        grab.grabButton = "Joy" + name + "Action1";

        players.Add(newPlayer);

        newPlayer.transform.position = getSpawnPoints()[int.Parse(name) - 1].transform.position;
    }

    public GameObject[] getSpawnPoints()
    {
        var gameSpawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);
        if (gameSpawnPoints.Length != 4)
        {
            Debug.LogError("Map doesn't have 4 spawnpoints for players");
        }
        return gameSpawnPoints;
    }

    public void removePlayer(string name)
    {
        if (playerExists(name))
        {
            foreach (var p in players)
            {
                if (p.GetComponent<PlayerInfo>().playerName == name)
                {
                    players.Remove(p);
                    Destroy(p);
                    return;
                }
            }
        }
    }

    private bool playerExists(string name)
    {
        foreach (var p in players)
        {
            if (p.GetComponent<PlayerInfo>().playerName == name)
            {
                return true;
            }
        }
        return false;
    }
}
