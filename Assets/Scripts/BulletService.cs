
using System;
using UnityEngine;

public static class BulletService
{

    private static BulletModel bulletModel = new BulletModel();
    private static BulletController bulletController = new BulletController();
    private static BulletView bulletView = new BulletView();


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

    public static GameObject GetBullet()
    {
       GameObject tempBullet= bulletController.SpawnBullet(bulletModel);
        return tempBullet;
    }

    public static float GetBulletSpeed()
    {
        return bulletModel.GetBulletSpeed();
    }
}
