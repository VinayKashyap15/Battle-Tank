using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel 
{
    private float pointDamage;
    private float bulletSpeed;
    private float bulletLife;
    private Vector3 bulletPosition;

    public BulletModel()
    {
        pointDamage = 10f;
        bulletSpeed = 8f;
        bulletLife = 3f;
        bulletPosition = new Vector3(0,0,0);
    }
    public float GetPointDamage()
    {
        return pointDamage;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public float GetBulletLife()
    {
        return bulletLife;
    }

    public Vector3 GetBulletPosition()
    {
        return bulletPosition;
    }
}
