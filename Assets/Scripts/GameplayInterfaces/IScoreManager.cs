using UnityEngine;
using Player;
using SceneSpecific;
using System.Collections.Generic;
using System;

namespace GameplayInterfaces
{
    public interface IScoreManager:IService
    {
        void SetSceneController(SceneController _sceneController);
        void AddPlayerUI(PlayerController _playerControllerInstance);
        void UpdateScoreView(PlayerController _p, int _score, int _playerID);
        void PopulateHighScoreTexts(string _highScoreText);
        List<string> GetHighScoreTextList();
        void OnAchievementUnlocked(string _achievementText);
    }
}