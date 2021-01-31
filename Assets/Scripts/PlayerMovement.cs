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
    public ParticleSystem ps;
    public string floorTag;
    private ParticleSystem.EmissionModule emission;
    private Transform floor;
    public PlayerSoundHandler sounds;
    public float minMovementToSound;
    public float maxMovementToSound;
    void Start()
    {
        if (controller is null)
        {
            // controller = gameObject.AddComponent<CharacterController>();
        }
        rb = GetComponent<Rigidbody>();
        playerName = GetComponent<PlayerInfo>().playerName;
        emission = ps.emission;
        ps.Play();
        emission.enabled = false;

        floor = GameObject.FindGameObjectWithTag(floorTag).transform;
        transform.position = new Vector3(transform.position.x, floor.position.y + floor.localScale.y / 2, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        var movementWithoutY = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        sounds.setMoving(movementWithoutY.magnitude > minMovementToSound, Mathf.Lerp(0, 1, movementWithoutY.magnitude / maxMovementToSound));

    }

    void FixedUpdate()
    {
        if (transform.position.y != floor.position.y)
        {
            transform.position = new Vector3(transform.position.x, floor.position.y + floor.localScale.y / 2, transform.position.z);
        }
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
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }

    void fixYPosition()
    {
        playerBase.transform.position = new Vector3(playerBase.transform.position.x,
                                                    playerYPosition,
                                                    playerBase.transform.position.z);
    }
}
