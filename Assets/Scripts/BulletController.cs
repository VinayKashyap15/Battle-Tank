using System;
using UnityEngine;

public class BulletController
{
    private BulletView bulletView;
    private BulletModel bulletModel;
    private static GameObject bullet;

    public BulletController()
    {
        bulletModel = CreateModel();
        if (!bullet)
        {
            GameObject _bullet = Resources.Load("Bullet") as GameObject;

            bullet = GameObject.Instantiate(_bullet);
        }

        bulletView = bullet.GetComponent<BulletView>();
    }

    protected virtual  BulletModel CreateModel()
    {
        return new BulletModel();
    }

    public GameObject GetBullet()
    {
        return bullet;
    }

    public float GetBulletSpeed()
    {
        return bulletModel.GetBulletSpeed();
    }
}
