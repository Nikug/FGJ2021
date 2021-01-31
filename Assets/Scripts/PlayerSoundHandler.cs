using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundHandler : MonoBehaviour
{
    public AudioSource moveSound;
    public AudioSource pickupSound;

    private bool isMoving;
    private float loudness;

    public void setMoving(bool move, float volume)
    {
        isMoving = move;
        loudness = volume;
    }

    public void pickUp()
    {
        pickupSound.Play();
    }

    void Update()
    {
        moveSound.volume = loudness;
        if (isMoving)
        {
            if (!moveSound.isPlaying)
            {
                moveSound.Play();
            }
        }
        else
        {
            if (moveSound.isPlaying)
            {
                moveSound.Pause();
            }
        }
    }
}
