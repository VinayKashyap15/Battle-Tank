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
