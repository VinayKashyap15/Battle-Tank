using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerView :MonoBehaviour
{
   
    private GameObject cam;
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]
    private GameObject muzzlePoint;
    private Rigidbody bulletRb;

    private void Start()
    {
        DisplayPlayerStats();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
       
    }
    

    public IEnumerator MovePlayer(float h,float v,float speed)
    {
        transform.Translate(new Vector3( h*speed*Time.deltaTime,0, v*speed*Time.deltaTime));
        yield return null;
    }

    public IEnumerator RotatePlayer(float pitch)
    {
        transform.Rotate(new Vector3(0, pitch, 0));
        yield return null;
    }

    public void DisplayFireMessage(string message)
    {
        Debug.Log(message);
    }

    public void DisplayPlayerStats()
    {
        PlayerModel model = new PlayerModel();
        int id = model.GetID();
        string name = model.GetName();

        Debug.Log("Player Name:" + name + "Player ID:" + id.ToString());
    }

    public void OnFirePressed(float bulletSpeed)
    {
        //fire
       
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.transform.position, Quaternion.identity) as GameObject;
        bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;

        DisplayFireMessage("Fire Button Pressed");
    }

}