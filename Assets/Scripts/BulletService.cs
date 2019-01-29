
using System;
using UnityEngine;

public static class BulletService 
{

    private static BulletModel bulletModel;
    private static BulletController bulletController;
    private static BulletView bulletView;

    public static void StartService()
    {
        bulletModel = new BulletModel();
    }

    public static BulletView GetBulletView()
    {
        return bulletView;
    }

    public static BulletController GetBulletController()
    {
        return bulletController;
    }

    public static BulletModel GetBulletModel()
    {
        return bulletModel;
    }

    //public static GameObject GetBullet()
    //{
    //   GameObject tempBullet= bulletController.SpawnBullet();
    //    return tempBullet;
    //}

    public static float GetBulletSpeed()
    {
        return bulletModel.GetBulletSpeed();
    }

    public static GameObject SpawnBullet()
    {
        bulletController = new BulletController();
        return bulletController.GetBullet();
    }
}
