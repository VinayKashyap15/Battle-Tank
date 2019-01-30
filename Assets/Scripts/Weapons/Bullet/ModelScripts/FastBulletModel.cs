public class FastBulletModel : BulletModel
{
   private float bulletSpeed; 

   public FastBulletModel()
    {
        bulletSpeed = 10f;
    }
    public override float GetBulletSpeed()
    {
        return bulletSpeed;
    }
}
