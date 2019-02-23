using UnityEngine;
using UnityEngine.UI;
using Common;
using System.Collections.Generic;
using SceneSpecific;

namespace Player.UI
{
    public class ScoreManager : SingletonBase<ScoreManager>
    {
        private void Start() {
            AchievementSystem.AchievementManager.Instance.OnAchievementCrossed+=OnAchievementUnlocked;
        }
        private SceneController sceneController;
        private List<string> highScoreTexts = new List<string>();

        public void SetSceneController(SceneController _scemeController)
        {
            sceneController = _scemeController;
        }

        public void AddPlayerUI(PlayerController _playerControllerInstance)
        {
            sceneController.SpawnPlayerUI(_playerControllerInstance);
        }

        public void UpdateScoreView(PlayerController _p, int _score,int _playerID)
        {
            sceneController.UpdateScoreView( _p,  _score,_playerID);
        }

        public void PopulateHighScoreTexts(string _highScoreText)
        {
            highScoreTexts.Add(_highScoreText);
        }
        public List<string> GetHighScoreTextList()
        {
            return highScoreTexts;
        }
       
        public void OnAchievementUnlocked(string _achievementText)
        {
            Debug.Log(_achievementText);
        }

    }
}
