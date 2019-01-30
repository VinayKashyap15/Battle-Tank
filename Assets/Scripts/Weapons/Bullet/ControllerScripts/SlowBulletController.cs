using Bullet.ModelScripts;
using Bullet.ViewScripts;

namespace Bullet.ControllerScripts
{
    public class SlowBulletController : BulletController
    {


        protected override BulletModel CreateModel()
        {
            return new SlowBulletModel();
        }
    }
}