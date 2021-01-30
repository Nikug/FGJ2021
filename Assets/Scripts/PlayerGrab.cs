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
    public string parentTag;
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
                var playerInfo = transform.GetComponent<PlayerInfo>();
                component.grab(playerInfo.playerName);
                isCarrying = true;
                heldItem = collider.gameObject;
                return;
            }
        }
    }

    private void Yeeeeet(GameObject child, float direction)
    {
        var body = child.GetComponent<Rigidbody>();
        body.AddForce(this.transform.forward * throwForce * (direction), ForceMode.Impulse);
        var grabbable = child.GetComponent<Grabbable>();
        grabbable.free();
    }

    private void handleDrop()
    {
        var colliders = Physics.OverlapSphere(grabPoint.position, grabRadius);
        foreach (var collider in colliders)
        {
            if (collider.tag == parentTag)
            {
                var component = collider.GetComponent<MiserableParent>();
                var childWasApproved = component.offerChild(heldItem.GetComponent<ToddlerInfo>().toddlerInfo);

                Debug.Log("childWasApproved");
                Debug.Log(childWasApproved);
                if (childWasApproved)
                {
                    Destroy(heldItem);
                    ChildMachine.deleteChild();
                }
                else
                {
                    this.Yeeeeet(heldItem, -1);
                }

                heldItem = null;
                isCarrying = false;

                return;
            }
        }

        this.Yeeeeet(heldItem, 1);

        isCarrying = false;
        heldItem = null;
    }

    private void drawDebugs()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(grabPoint.position, grabRadius);
    }
}
