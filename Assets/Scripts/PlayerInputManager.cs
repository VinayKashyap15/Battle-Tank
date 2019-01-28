using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{

    public PlayerModel model;
    public PlayerController controller;
    

    bool isMoving = false;

    void Start()
    {
        controller= new PlayerController(gameObject.GetComponent<PlayerView>());
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal1");
        float v = Input.GetAxis("Vertical1");

        if (h != 0 || v != 0)
        { isMoving = true; }
        else
        { isMoving = false; }

        if (isMoving)
        {
           controller.Move(h, v);
        }

        if (Input.GetMouseButtonDown(0))
        {
            controller.Fire();
        }
        if (Input.GetAxis("Mouse X") != 0)
        {
            float pitch = Input.GetAxis("Mouse X");
            controller.RotateCamera(pitch);
        }
    }
}
