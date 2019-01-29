using UnityEngine;

public class BulletController
{
    private BulletView bulletView;
    //private BulletModel _bulletModel;
    GameObject bullet;

    public  BulletController()
    {
        bullet=SpawnBullet();
        bulletView =bullet.GetComponent<BulletView>();
        
    }

    public GameObject SpawnBullet()
    {
        GameObject _bullet = Resources.Load("Bullet") as GameObject;
        return _bullet;
    }
    public GameObject GetBullet()
    {
        return bullet;
    }
}
