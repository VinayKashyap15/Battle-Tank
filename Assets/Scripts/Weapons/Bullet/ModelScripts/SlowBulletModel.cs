namespace Bullet.Model
{
    public class SlowBulletModel : BulletModel
    {
        public SlowBulletModel()
        {
            bulletSpeed = 1f;
        }
        public override float GetBulletSpeed()
        {
            return bulletSpeed;
        }
    }
}