public class FastBulletController : BulletController
{
   // FastBulletModel fastBulletModel;

    public FastBulletController()
    {
        
    }
    protected override BulletModel CreateModel()
    {
        return new FastBulletModel();
    }
}
