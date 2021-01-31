using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool grabbed;
    public string lastToucher;
    public string floorTag;
    public string wallTag = "Wall";
    public ChildSoundHandler sounds;

    public void grab(string playerName)
    {
        sounds.playRandomSound(1f);
        var collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        var agent = GetComponent<MoveTo>();
        agent.DisableAgent();
        lastToucher = playerName;
    }

    public void free()
    {
        var collider = GetComponent<CapsuleCollider>();
        collider.isTrigger = true;
        collider.enabled = true;
        var agent = GetComponent<MoveTo>();
        agent.enableAgentOnTouch = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == floorTag || other.tag == wallTag)
        {
            var collider = GetComponent<CapsuleCollider>();
            collider.isTrigger = false;
        }
    }
}
