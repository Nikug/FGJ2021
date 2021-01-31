using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncementHandler : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    public float minTime;
    public float maxTime;

    void Start()
    {
        StartCoroutine(waitAndPlay());
    }

    IEnumerator waitAndPlay()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }
}
