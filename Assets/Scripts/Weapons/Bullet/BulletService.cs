using Common;
using Player;
using ServiceLocator;
using ObjectPooling;
using Bullet.Controller;
using GameplayInterfaces;
using Bullet.Model;


namespace Weapons.Bullet
{
    public class BulletService : IBulletService
    {
        private BULLET_TYPE typeOfBullet;
        private PlayerController playerControllerInstance;

        private ObjectPool<BulletController> objectPool;

        public BulletService(BULLET_TYPE _typeOfBullet)
        {
            typeOfBullet = _typeOfBullet;
            objectPool=new ObjectPool<BulletController>();
        }


        public BulletController SpawnBullet(PlayerController _currentPlayerControllerInstance)
        {
            playerControllerInstance = _currentPlayerControllerInstance;
            GameApplication.Instance.GetService<IPlayerService>().SetCurrentInstance(playerControllerInstance);

            switch (typeOfBullet)
            {
                case BULLET_TYPE.Default:
                    {
                        BulletController _newbullet= objectPool.Get<BulletController>();
                        _newbullet.SetViewActive();
                        return _newbullet;
                        break;
                    }
                case BULLET_TYPE.Fast:
                    {
                        BulletController _newbullet= objectPool.Get<FastBulletController>();                                            
                        return _newbullet;
                        break;
                    }
                case BULLET_TYPE.Slow:
                    {
                        BulletController _newbullet= objectPool.Get<SlowBulletController>();                                                                    
                        return _newbullet;
                        break;
                    }
                default:
                    {
                        BulletController _newbullet= objectPool.Get<BulletController>();                        
                        return _newbullet;
                        break;
                    }
            }
        }

        public void DestroyController(BulletController _bulletController)
        {
            //_bulletController.Reset();
            //objectPool.ReturnToPool(_bulletController);
            _bulletController.StartDestroy();
            //_bulletController = null;
        }
        public void DisableController(BulletController _bulletController)
        {
            _bulletController.Reset();
            objectPool.ReturnToPool(_bulletController);
            //_bulletController.StartDestroy();
            //_bulletController = null;
        }
        public PlayerController GetPlayerControllerInstance()
        {
            return playerControllerInstance;
        }
        public float GetBulletSpeed(BulletModel _model)
        {
            return _model.GetBulletSpeed();
        }

    }
}
