namespace EnemyStates
{
    public interface IEnemyState
    {
        void OnStateEnter();
        void OnStateExit();
        void OnStateUpdate();
    }
}