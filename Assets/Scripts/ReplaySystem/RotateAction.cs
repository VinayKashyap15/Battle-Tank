using GameplayInterfaces;


namespace InputComponents
{
    public class RotateAction :InputActions
    {
        private float pitch;
        
        public RotateAction(float _pitch)
        {
            pitch=_pitch;
        }        
        public override void Execute(ICharacterController controller)
        {
            controller.Rotate(pitch);       
        }
    }
}