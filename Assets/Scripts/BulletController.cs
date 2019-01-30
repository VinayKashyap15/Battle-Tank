using System;
using UnityEngine;

public class BulletController
{
    
    private GameObject bulletPrefab;

    public BulletController()
    {
       BulletModel bulletModel = CreateModel();
        if (!bulletPrefab)
        {
            GameObject _bulletPrefab = Resources.Load("Bullet") as GameObject;

            bulletPrefab = GameObject.Instantiate(_bulletPrefab);
        }
       BulletView bulletView = bulletPrefab.GetComponent<BulletView>();
    }

    protected virtual BulletModel CreateModel()
    {
        return new BulletModel();
    }

    public GameObject GetBullet()
    {
        return bulletPrefab;
    }

    public float GetBulletSpeed()
    {
        return bulletModel.GetBulletSpeed();
    }
}
