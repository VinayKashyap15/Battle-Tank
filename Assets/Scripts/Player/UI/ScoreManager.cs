using UnityEngine;
using Common;
using SceneSpecific;

namespace Player.UI
{
    public class ScoreManager : SingletonBase<ScoreManager>
    {
        
        private SceneController sceneController;

        public void SetSceneController(SceneController _scemeController)
        {
            sceneController = _scemeController;
        }

        public void AddPlayerUI(PlayerController _playerControllerInstance)
        {
            sceneController.SpawnPlayerUI(_playerControllerInstance);
        }

        public void UpdateScoreView(PlayerController _p, int _score)
        {
            sceneController.UpdateScoreView( _p,  _score);
        }
    }
}
