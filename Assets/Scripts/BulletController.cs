using UnityEngine;

public class BulletController
{
    private BulletView bulletView;
    //private BulletModel _bulletModel;
    GameObject _bullet;
    public  BulletController()
    {
        _bullet=SpawnBullet();
        bulletView =_bullet.GetComponent<BulletView>();
        
    }

    public GameObject SpawnBullet()
    {
        GameObject bullet = Resources.Load("Bullet") as GameObject;
        return bullet;
    }
    public GameObject GetBullet()
    {
        return _bullet;
    }
}
