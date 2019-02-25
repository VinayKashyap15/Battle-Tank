using UnityEngine;
using UnityEngine.UI;
using ServiceLocator;
using Common;
using GameplayInterfaces;
using System.Collections.Generic;
using SceneSpecific;
using System;
using System.Collections;

namespace Player.UI
{
    public class ScoreManager : IScoreManager
    {
        private SceneController sceneController;
        private List<string> highScoreTexts = new List<string>();
        GameObject achievementInstance;
        public ScoreManager()
        {
            OnStart();
        }
        public void OnStart()
        {
            AchievementSystem.AchievementManager.Instance.OnAchievementCrossed += OnAchievementUnlocked;
            GameApplication.Instance.GetService<IStateMachineService>().OnPause += OnPauseScreen;
            GameApplication.Instance.GetService<IStateMachineService>().OnResume += OnResumeScreen;
            GameApplication.Instance.GetService<IStateMachineService>().OnStartReplay += OnStartReplayUI;
            GameObject achivementUI = Resources.Load("AchievementUI") as GameObject;
            achievementInstance = GameObject.Instantiate(achivementUI);
            achivementUI.transform.SetParent(sceneController.GetCanvasParent());
            achivementUI.SetActive(false);
        }

        private void OnStartReplayUI()
        {
            sceneController.SpawnReplayUI();
        }

        private void OnPauseScreen()
        {
            
        }

        private void OnResumeScreen()
        {
            
        }

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
            //spawn achievment UI;

        }

        IEnumerator AchievementCoRou(string _achievementText)
        {
            
            Text text=achievementInstance.GetComponent<Text>();
            text.text = _achievementText;
            achievementInstance.gameObject.SetActive(false);

            yield return new WaitForSeconds(2);
            achievementInstance.gameObject.SetActive(false);

            yield return null;

        }

    }
}
