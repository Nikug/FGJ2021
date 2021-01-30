using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool grabbed;

    public void grab() {
        var collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        var agent = GetComponent<MoveTo>();
        agent.DisableAgent();
    }

    public void free() {
        var collider = GetComponent<CapsuleCollider>();
        collider.enabled = true;
        var agent = GetComponent<MoveTo>();
        agent.EnableAgent();
    }
}
