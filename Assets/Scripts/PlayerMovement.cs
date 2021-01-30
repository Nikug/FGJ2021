using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerYPosition;
    public GameObject playerBase;
    /* Player Movement */
    private CharacterController controller;
    public float playerSpeed = 6.0f;


    /* Player Inputs */
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";
    public string extrabutton;
    private string playerName;
    private Rigidbody rb;
    void Start()
    {
        if (controller is null)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
        rb = GetComponent<Rigidbody>();
        playerName = GetComponent<PlayerInfo>().playerName;
    }

    // Update is called once per frame
    void Update()
    {
        /* Movement */
        // Move();
        /* Fix to Player Y Position */

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis(horizontal), 0, Input.GetAxis(vertical) * -1);
        // controller.Move(Vector3.Normalize(move) * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            // gameObject.transform.forward = move;
            rb.velocity = Vector3.Normalize(move) * playerSpeed;
            rb.rotation = Quaternion.LookRotation(move, Vector3.up);
            // transform.Translate(Vector3.Normalize(move) * Time.deltaTime * playerSpeed);
        }
    }

    void fixYPosition()
    {
        playerBase.transform.position = new Vector3(playerBase.transform.position.x,
                                                    playerYPosition,
                                                    playerBase.transform.position.z);
    }
}
