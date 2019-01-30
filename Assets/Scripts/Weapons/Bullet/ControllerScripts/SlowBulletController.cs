public class SlowBulletController : BulletController
{


    protected override BulletModel CreateModel()
    {
        return new SlowBulletModel();
    }
}
