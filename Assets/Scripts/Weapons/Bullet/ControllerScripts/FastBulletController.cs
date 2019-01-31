using Player;
using Bullet.ModelScripts;
using Bullet.ViewScripts;

namespace Bullet.ControllerScripts
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
