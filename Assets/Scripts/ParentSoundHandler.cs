using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSoundHandler : MonoBehaviour
{
    public AudioSource source;
    public AudioClip yes;
    public AudioClip no;

    public void AcceptSound()
    {
        source.PlayOneShot(yes);
    }

    public void RejectSound()
    {
        source.PlayOneShot(no);
    }
}
