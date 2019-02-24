using ReplaySystem;
using System.Collections.Generic;
using InputComponents;

namespace GameplayInterfaces
{
    public interface IReplayService : IService
    {
        void SetSceneController(SceneSpecific.SceneController _controller);
        bool GetReplayValue();
        void ClearQueue();
        void SaveQueue(QueueData _dataToSave);
        Queue<QueueData> GetSavedQueue();
        void SaveSpawnPointData(int _id, int _frameNo, InputActions _spawnAction);
    }
}