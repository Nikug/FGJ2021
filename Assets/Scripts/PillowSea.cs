using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowSea : MonoBehaviour
{
    public string toddlerTag;
    public ParticleSystem ps;
    private int eatenChildren = 0;
    public int oksennusLimit = 5;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == toddlerTag)
        {
            ps.Play();
            other.gameObject.AddComponent<ConsumeChild>();
            eatenChildren += 1;

            if (eatenChildren >= oksennusLimit) {
                ChildMachine.spawnChaos();
                eatenChildren -= oksennusLimit;
            }
        }
    }
}
