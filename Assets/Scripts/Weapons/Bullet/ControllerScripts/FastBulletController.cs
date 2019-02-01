using Player;
using Bullet.Model;
using Bullet.View;

namespace Bullet.Controller
{
    public class FastBulletController : BulletController
    {
        public FastBulletController()
        {            
            
        }
        protected override BulletModel CreateModel()
        {
            return new FastBulletModel();
        }
    }
}
