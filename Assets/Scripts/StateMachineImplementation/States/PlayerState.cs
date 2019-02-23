namespace PlayerStates
{
    public abstract class PlayerState
    {
        public abstract void OnStateEnter();
        public abstract void OnStateExit();
        public abstract void OnStateUpdate();
    }
}