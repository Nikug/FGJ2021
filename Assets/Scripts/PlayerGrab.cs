using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public bool debug = false;
    public string grabButton;
    public bool canGrab = false;
    public bool isCarrying = false;
    [SerializeField] private GameObject heldItem;
    public Transform grabPoint;
    public float grabRadius;
    public float throwForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown(grabButton))
        {
            if (isCarrying)
            {
                handleDrop();
            }
            else
            {
                handleGrab();
            }
        }
    }

    void LateUpdate()
    {
        if (heldItem)
        {
            heldItem.transform.position = grabPoint.position;
        }
    }

    void OnDrawGizmos()
    {
        if (debug)
        {
            drawDebugs();
        }
    }

    private void handleGrab()
    {
        if (!canGrab || isCarrying) return;

        var colliders = Physics.OverlapSphere(grabPoint.position, grabRadius);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Grabbable>(out var component))
            {
                component.grab();
                isCarrying = true;
                heldItem = collider.gameObject;
                return;
            }
        }
    }

    private void handleDrop()
    {
        var body = heldItem.GetComponent<Rigidbody>();
        body.AddForce(this.transform.forward * throwForce, ForceMode.Impulse);
        var grabbable = heldItem.GetComponent<Grabbable>();
        grabbable.free();

        isCarrying = false;
        heldItem = null;
    }

    private void drawDebugs()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(grabPoint.position, grabRadius);
    }
}
