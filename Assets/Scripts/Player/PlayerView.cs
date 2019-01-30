﻿using UnityEngine;
using Bullet.ControllerScripts;
using System;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {

        [SerializeField]
        private GameObject muzzlePoint;

        private Rigidbody bulletRb;

        public void MovePlayer(float h, float v, float speed)
        {
            transform.Translate(new Vector3(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime));

        }

        public void RotatePlayer(float pitch)
        {
            transform.Rotate(new Vector3(0, pitch, 0));
        }

        public void OnFirePressed()
        {
                        
            Debug.Log("Fire Button Pressed");
        }

       

        public Vector3 GetMuzzlePosition()
        {
            return muzzlePoint.transform.position;
        }

        public Quaternion GetMuzzleRotation()
        {
            return muzzlePoint.transform.rotation;
        }
        public Vector3 GetMuzzleDirection()
        {
            return muzzlePoint.transform.forward;
        }
    }
}