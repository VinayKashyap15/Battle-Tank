using UnityEngine;

public class BulletController
{
    private BulletView bulletView;
    //private BulletModel _bulletModel;

    public BulletController()
    {
        bulletView = BulletService.GetBulletView();
        //bulletModel = BulletService.GetBulletModel();
    }

    public GameObject SpawnBullet(BulletModel _bullet)
    {
        GameObject bullet= bulletView.SpawnBullet(_bullet);
        return bullet;
    }
}
