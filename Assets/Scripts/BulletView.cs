using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public virtual void SetMaterial()
    {
    }
    public void DestroyBullet()
    {
        DestroyImmediate(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }
}
