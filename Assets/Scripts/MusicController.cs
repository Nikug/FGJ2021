using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioSource source;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        if (gameController.gameState == GameController.GameState.MainMenu)
        {
            source.clip = menuMusic;
        }
        else
        {
            source.clip = gameMusic;
        }
        source.Play();
    }

    void Update()
    {
        if (gameController.gameState == GameController.GameState.MainMenu)
        {
            if (source.clip.name != menuMusic.name)
            {
                source.clip = menuMusic;
            }
        }
        else
        {
            if (source.clip.name != gameMusic.name)
            {
                source.clip = gameMusic;
            }
        }
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
}
