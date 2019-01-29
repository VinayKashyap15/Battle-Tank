using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    protected virtual void SetMaterial()
    {
    }
    protected virtual void DestroyBullet()
    {
        DestroyImmediate(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }
}
