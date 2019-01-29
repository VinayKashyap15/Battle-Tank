using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBulletModel : BulletModel {

    private float bulletSpeed;

    public SlowBulletModel()
    {
        bulletSpeed = 1f;
    }
    public override float GetBulletSpeed()
    {
        return bulletSpeed;
    }
}
