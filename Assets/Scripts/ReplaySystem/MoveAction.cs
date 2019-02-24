using GameplayInterfaces;


namespace InputComponents
{
    public class MoveAction :InputActions
    {
        private float horizontalVal;
        private float verticalVal;
        public MoveAction(float _horizontal,float _vertical)
        {
            horizontalVal=_horizontal;
            verticalVal=_vertical;
        }        
        public override void Execute(ICharacterController controller)
        {
            controller.Move(horizontalVal,verticalVal);            
        }
    }
}