using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerView : MonoBehaviour
{

    [SerializeField]
    private GameObject muzzlePoint;

    private Rigidbody bulletRb;

    private void Start()
    {

    }


    public void MovePlayer(float h, float v, float speed)
    {
        transform.Translate(new Vector3(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime));

    }

    public void RotatePlayer(float pitch)
    {
        transform.Rotate(new Vector3(0, pitch, 0));
    }

    public void OnFirePressed(GameObject _bullet, float _bulletSpeed)
    {
        //fire
      

        Debug.Log("Fire Button Pressed");
    }

}