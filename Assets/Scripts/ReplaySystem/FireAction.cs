using GameplayInterfaces;


namespace InputComponents
{
    public class FireAction : InputActions
    {
        public override void Execute(ICharacterController controller)
        {
            controller.Fire();
            controller.SetFireState(true);
        }
    }
}