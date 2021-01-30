using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPlayerMovement : MonoBehaviour
{
    public float playerYPosition;
    private string area;
    public GameObject playerBase;
    /* Player Movement */
    private CharacterController controller;
    public float playerSpeed = 6.0f;
    

    /* Player Inputs */
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";
    public string menubutton;
    public GameObject playbutton;
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        /* Movement */
        Move();
        /* Fix to Player Y Position */
        fixYPosition();

        OnClickMenu(area);
    }

    void Move() {
        Vector3 move = new Vector3(Input.GetAxis(horizontal), 0, Input.GetAxis(vertical));
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    void fixYPosition() {
        playerBase.transform.position = new Vector3 (playerBase.transform.position.x,
                                                    playerYPosition, 
                                                    playerBase.transform.position.z);
    }

    void OnClickMenu(string area)
    {
        if (Input.GetButton(menubutton))
        {
            Debug.Log("Is click");
            if (area == "PlayButton")
            {
                Debug.Log("is play time");
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

            }
            /*
            else if (area == "InfoButton")
            {
                infotext.SetActive(true);
                Debug.Log("is info time");
            }
            else if (area == "ExitButton")
            {
                //Debug.Log("is exit time");
                Application.Quit();
            }
            */
        }
    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.gameObject.tag + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "PlayButton")
        {
            //Debug.Log("setting area: play");
            area = "PlayButton";
        }
        /*
        else if (col.gameObject.tag == "InfoButton")
        {
            //Debug.Log("setting area: info");
            area = "InfoButton";
        }
        else if (col.gameObject.tag == "ExitButton")
        {
            //Debug.Log("setting area: exit");
            area = "ExitButton";
        }
        */
        else
        {
            Debug.Log("setting area: none");
            area = "none";
        }

    }
    void OnTriggerEnter (Collider col) {
        string hitObject = col.gameObject.tag;
        //Debug.Log("I collided with the " + hitObject + " !");
  }
    /*
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Boat" || col.gameObject.tag == "Plank" || col.gameObject.tag == "PlayButton" || col.gameObject.tag == "InfoButton" || col.gameObject.tag == "ExitButton")
        {
            //speed = 1;
            area = "none";
        }
    }
    */

}
