using Bullet.Model;
using Bullet.View;

namespace Bullet.Controller
{
    public class SlowBulletController : BulletController
    {


        protected override BulletModel CreateModel()
        {
            return new SlowBulletModel();
        }
    }
}