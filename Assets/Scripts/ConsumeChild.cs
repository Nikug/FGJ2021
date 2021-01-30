using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeChild : MonoBehaviour
{
    public float timeToLive = 2f;
    public float sinkDistance = 2f;
    private Vector3 sinkStart;
    private Vector3 sinkEnd;
    private float t;

    void Start()
    {
        if (TryGetComponent<Grabbable>(out Grabbable component))
        {
            component.grab("pillows");
        }
        sinkStart = transform.position;
        sinkEnd = transform.position - new Vector3(0f, sinkDistance, 0f);
        t = timeToLive;
    }

    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0f)
        {
            // Call decrease child count
            Destroy(gameObject);
        }
        Destroy(gameObject.GetComponent<Rigidbody>());
        transform.position = Vector3.Slerp(sinkStart, sinkEnd, (timeToLive - t) / timeToLive);
    }
}
