using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject SpawnBullet(BulletModel _bulletModel)
    {
        GameObject bullet = Resources.Load("Bullet")as GameObject;
        
        bullet.AddComponent<Rigidbody>();

        return bullet;
    }
}
