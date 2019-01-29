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
        _bullet.transform.position = muzzlePoint.transform.position;
        _bullet.transform.rotation = muzzlePoint.transform.rotation;
        _bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50f * _bulletSpeed * Time.deltaTime), ForceMode.Impulse);
        Debug.Log("Fire Button Pressed");
    }

}