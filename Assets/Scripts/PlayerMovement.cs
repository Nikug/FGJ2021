using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
<<<<<<< HEAD
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
=======
    public float playerSpeed = 6.0f;
    public float playerYPosition;
    public GameObject playerBase;
>>>>>>> 410d3c125de8648e9d2f66b0f137b16a1bb663ca
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        /* Movement */
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        /* Fix to Player Y Position */
        playerBase.transform.position = new Vector3 (playerBase.transform.position.x,
                                                    playerYPosition, 
                                                    playerBase.transform.position.z);
    }
}
