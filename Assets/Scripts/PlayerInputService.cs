using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputService : MonoBehaviour
{

    public PlayerController playerController;

    private bool isMoving;

    void Start()
    {
        BulletService.StartService();
        playerController = new PlayerController(gameObject.GetComponent<PlayerView>());
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal1");
        float v = Input.GetAxis("Vertical1");
        float pitch = Input.GetAxis("Mouse X");

        if (h != 0 || v != 0)
        { isMoving = true; }
        else
        { isMoving = false; }

        if (isMoving)
        {
            playerController.Move(h, v);
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerController.Fire();
        }
        if (pitch != 0)
        {
            playerController.RotatePlayer(pitch);
        }
    }
}
