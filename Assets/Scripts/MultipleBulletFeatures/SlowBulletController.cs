using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBulletController : BulletController
{


    protected override BulletModel CreateModel()
    {
        return new SlowBulletModel();
    }
}
