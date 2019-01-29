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

    public GameObject SpawnBullet()
    {
        GameObject bullet = Resources.Load("Bullet")as GameObject;
        bullet.AddComponent<Rigidbody>();

        return bullet;
    }
    //public void MoveBullet(GameObject _bullet)
    //{
    //    _bullet.transform.position = muzzlePoint.transform.position;
    //    _bullet.transform.rotation = muzzlePoint.transform.rotation;
    //    _bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50f * _bulletSpeed * Time.deltaTime), ForceMode.Impulse);
    //}
    
}
