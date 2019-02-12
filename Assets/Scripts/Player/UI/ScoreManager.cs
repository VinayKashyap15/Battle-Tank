using UnityEngine;
using UnityEngine.UI;
using Common;
using System.Collections.Generic;
using SceneSpecific;
using System;

namespace Player.UI
{
    public class ScoreManager : SingletonBase<ScoreManager>
    {
        private void Start()
        {
            AchievementSystem.AchievementManager.Instance.OnAchievementCrossed += OnAchievementUnlocked;
            StateMachineImplementation.StateMachineService.Instance.OnPause += OnPauseScreen;
            StateMachineImplementation.StateMachineService.Instance.OnResume += OnResumeScreen;
            StateMachineImplementation.StateMachineService.Instance.OnStartReplay+=OnStartReplayUI;
        }

        private void OnStartReplayUI()
        {
            sceneController.SpawnReplayUI();
        }

        private void OnPauseScreen()
        {
            Debug.Log("Score manager pause debug");
        }

        private void OnResumeScreen()
        {
            Debug.Log("Score manager resume debug");
        }
        private SceneController sceneController;
        private List<string> highScoreTexts = new List<string>();

        public void SetSceneController(SceneController _sceneController)
        {
            sceneController = _sceneController;
        }

        public void AddPlayerUI(PlayerController _playerControllerInstance)
        {
            sceneController.SpawnPlayerUI(_playerControllerInstance);
        }

        public void UpdateScoreView(PlayerController _p, int _score, int _playerID)
        {
            sceneController.UpdateScoreView(_p, _score, _playerID);
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
