using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string toddlerTag;
    public float overLapRadius = 1f;

    public bool check()
    {
        var colliders = Physics.OverlapSphere(transform.position, overLapRadius);
        foreach (var collider in colliders)
        {
            if (collider.tag == toddlerTag)
            {
                return false;
            }
        }
        return true;
    }
}
