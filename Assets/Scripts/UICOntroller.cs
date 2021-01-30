using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICOntroller : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void OpenMenu()
    {

    }
}
