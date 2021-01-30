﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool grabbed;
    public string lastToucher;

    public void grab(string playerName) {
        var collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        lastToucher = playerName;
    }

    public void free() {
        var collider = GetComponent<CapsuleCollider>();
        collider.enabled = true;
    }
}
