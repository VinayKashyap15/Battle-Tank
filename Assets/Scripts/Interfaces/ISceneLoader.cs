namespace GameplayInterfaces
{
    public interface ISceneLoader : IService
    {
        void OnClickPlay(string _string);
        void OnClickStart(string _string);
        void OnGameOver();
        void OnReplay();
        void OnReturnHome();
        
    }
}