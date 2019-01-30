public class BulletService : SingletonBase<BulletService>
{


    public BULLET_TYPE typeOfBullet;

    public float GetBulletSpeed(BulletModel _model)
    {
        return _model.GetBulletSpeed();
    }

    public BulletController SpawnBullet()
    {

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

    public void DestroyOldModels(BulletController _bulletController)
    {
        _bulletController.StartDestroy();
        _bulletController = null;
    }

}
