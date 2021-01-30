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
    void Start()
    {
        if (controller is null)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
        playerName = GetComponent<PlayerInfo>().playerName;
    }

    // Update is called once per frame
    void Update()
    {
        /* Movement */
        Move();
        /* Fix to Player Y Position */
        fixYPosition();
    }

    void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis(horizontal), 0, Input.GetAxis(vertical) * -1);
        controller.Move(Vector3.Normalize(move) * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    void fixYPosition()
    {
        playerBase.transform.position = new Vector3(playerBase.transform.position.x,
                                                    playerYPosition,
                                                    playerBase.transform.position.z);
    }
}
