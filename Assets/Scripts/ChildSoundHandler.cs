using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSoundHandler : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    public void playRandomSound(float spatialBlend = 0f)
    {
        source.spatialBlend = spatialBlend;
        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
