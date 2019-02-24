using RewardSystem;
using SceneSpecific;

namespace GameplayInterfaces
{
    public interface ILobbyService:IService
    {
        void OnStart();
        void SetSceneController(LobbySceneController _controller);
        void SavePlayerConfig(RewardProperties _currentProperty);
        void UnSubscribeDummyControllers();
        void OnButtonClicked(RewardProperties _property);
    }
}