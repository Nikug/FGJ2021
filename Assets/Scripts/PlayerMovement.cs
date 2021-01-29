using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float playerSpeed = 6.0f;
    public float playerYPosition;
    public GameObject playerObject;
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
        playerObject.transform.position = new Vector3(playerObject.transform.position.x,
                                                    playerYPosition, 
                                                    playerObject.transform.position.z);
    }
}
