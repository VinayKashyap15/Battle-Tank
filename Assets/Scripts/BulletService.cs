
using System;
using UnityEngine;


public  class BulletService : SingletonBase<BulletService>
{
    public enum BULLET_TYPE
    {
        Default,
        Fast,
        Slow
    };


    private BulletModel bulletModel;
    private  BulletController bulletController;

    public BULLET_TYPE typeOfBullet;
        
    public void StartService()
    {
        
    }

    public  float GetBulletSpeed(BulletModel _model)
    {
        return _model.GetBulletSpeed();
    }

    public BulletController SpawnBullet()
    {
      
      switch(typeOfBullet)
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
    
}
