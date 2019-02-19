using Bullet.Model;
using Player;
using Weapons.Bullet;
using Bullet.Controller;


namespace GameplayInterfaces
{
    public interface IBulletService : IService
    {
        void DestroyController(BulletController _bulletController);
        void DisableController(BulletController _bulletController);
        PlayerController GetPlayerControllerInstance();
        float GetBulletSpeed(BulletModel _model);
        BulletController SpawnBullet(PlayerController _currentPlayerControllerInstance);
    }
}