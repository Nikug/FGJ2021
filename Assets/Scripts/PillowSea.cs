using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowSea : MonoBehaviour
{
    public string toddlerTag;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == toddlerTag)
        {
            other.gameObject.AddComponent<ConsumeChild>();
        }
    }
}
