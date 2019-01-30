using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulletController : BulletController
{
   // FastBulletModel fastBulletModel;

    public FastBulletController()
    {
        
    }
    protected override BulletModel CreateModel()
    {
        return new FastBulletModel();
    }
}
