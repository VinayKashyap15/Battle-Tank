using Bullet.ModelScripts;
using Bullet.ViewScripts;

namespace Bullet.ControllerScripts
{
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
}
