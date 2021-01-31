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
    [SerializeField] private List<GameObject> players;
    private List<string> playerNames;

    public GameState gameState = GameState.Game;
    private List<Transform> spawnPoints;
    public string spawnPointTag = "PlayerSpawnpoint";
    public bool debugSpawnPlayers = false;
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
        playerNames = new List<string>();
        if (debugSpawnPlayers)
        {
            playerNames.Add("1");
            spawnPlayers();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
            if (players.Count > 0 && gameState == GameState.MainMenu)
            {
                {
                    StartGame();
                }
            }

        if (gameState == GameState.Game)
        {
            if (Input.GetButton("Start"))
            {
                // Open menu, pause game
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Loaded scene " + scene.name);
        if (scene.name == "GameScene")
        {
            spawnPlayers();
        }
    }

    public void StartGame()
    {
        this.gameState = GameState.Game;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "GameScene")
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }



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
            Debug.Log("Loading main menu");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public bool addPlayer(string name)
    {
        if (!playerExists(name))
        {
            playerNames.Add(name);
            var player = spawnSinglePlayer(name);
            players.Add(player);

            return true;
        }
        return false;
    }

    public void spawnPlayers()
    {
        players = new List<GameObject>();
        foreach (var name in playerNames)
        {
            var player = spawnSinglePlayer(name);
            players.Add(player);
        }
    }

    private GameObject spawnSinglePlayer(string name)
    {
        var newPlayer = Instantiate(player);
        newPlayer.GetComponent<PlayerInfo>().playerName = name;

        var controller = newPlayer.GetComponent<PlayerMovement>();
        controller.horizontal = "Joy" + name + "Axis1";
        controller.vertical = "Joy" + name + "Axis2";

        var grab = newPlayer.GetComponent<PlayerGrab>();
        grab.grabButton = "Joy" + name + "Action1";

        newPlayer.transform.position = getSpawnPoints()[int.Parse(name) - 1].transform.position;
        return newPlayer;
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
                    playerNames.Remove(name);
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

    public void givePoints(string playerName, int points) {
        foreach(var player in players) {
            var playerInfo = player.GetComponent<PlayerInfo>();
            if (playerInfo.playerName == playerName) {
                playerInfo.playerScore += points;
            }
        }
    }

    public int getPlayerScore(string playerName) {
        int playerScore = 0;

        foreach(var player in players) {
            var playerInfo = player.GetComponent<PlayerInfo>();
            if (playerInfo.playerName == playerName) {
                playerScore = playerInfo.playerScore;
            }
        }
        return playerScore;
    }
}
