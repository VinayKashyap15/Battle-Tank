using Common;
using Player;
using Bullet.ControllerScripts;
using Bullet.ModelScripts;


namespace Weapons.Bullet
{
    public class BulletService : SingletonBase<BulletService>
    {
        public BULLET_TYPE typeOfBullet;
        private PlayerController playerControllerInstance;
        public float GetBulletSpeed(BulletModel _model)
        {
            return _model.GetBulletSpeed();
        }

        public PlayerController GetPlayerControllerInstance()
        {
            return playerControllerInstance;
        }

        public BulletController SpawnBullet(PlayerController _currentPlayerControllerInstance)
        {
            playerControllerInstance=_currentPlayerControllerInstance;
            switch (typeOfBullet)
            {
                case BULLET_TYPE.Default:
                    return new BulletController();
                case BULLET_TYPE.Fast:
                    return new FastBulletController();
                case BULLET_TYPE.Slow:
                    return new SlowBulletController();
                default:
                    return new BulletController();
            }
        }

        public void DestroyController(BulletController _bulletController)
        {
            _bulletController.StartDestroy();
            _bulletController = null;
        }


    }
}
