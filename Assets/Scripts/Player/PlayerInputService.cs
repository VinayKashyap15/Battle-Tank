﻿using UnityEngine;
namespace Player
{
    public class PlayerInputService : MonoBehaviour
    {

        public PlayerController playerController;

        private bool isMoving;

        void Start()
        {
            // BulletService.StartService();
            playerController = new PlayerController(gameObject.GetComponent<PlayerView>());
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal1");
            float v = Input.GetAxis("Vertical1");
            float pitch = Input.GetAxis("Mouse X");

            
            if (h!=0||v!=0)
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
}
