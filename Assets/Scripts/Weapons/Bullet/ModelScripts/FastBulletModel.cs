namespace Bullet.Model
{
    public class FastBulletModel : BulletModel
    {
        public FastBulletModel()
        {
            bulletSpeed = 10f;
        }
        public override float GetBulletSpeed()
        {
            return bulletSpeed;
        }
    }
}
