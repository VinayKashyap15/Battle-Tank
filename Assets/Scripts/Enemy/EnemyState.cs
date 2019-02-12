namespace EnemyStates
{
    public abstract class EnemyState
    {
        public abstract void OnStateEnter();
        public abstract void OnStateExit();
        public abstract void OnStateUpdate();
    }
}