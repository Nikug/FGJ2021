using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowSea : MonoBehaviour
{
    public string toddlerTag;
    public ParticleSystem ps;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == toddlerTag)
        {
            ps.Play();
            other.gameObject.AddComponent<ConsumeChild>();
        }
    }
}
