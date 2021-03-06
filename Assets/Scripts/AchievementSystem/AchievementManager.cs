﻿using UnityEngine;
using Common;
using ServiceLocator;
using GameplayInterfaces;
using System.Collections.Generic;
using Player;
using Player.UI;
using System;
using SaveFile;

namespace AchievementSystem
{
    public class AchievementManager : SingletonBase<AchievementManager>
    {
        [SerializeField]
        private AchievementScriptableList achievementScriptableObj;
        private List<AchievementScriptableObject> _currentAchievementList = new List<AchievementScriptableObject>();
        public event Action<int, int> GamesJoined;

        private Dictionary<int, int> highScoreMark;
        private Dictionary<int, int> enemyKillMark;
        private Dictionary<int, int> gamePlayedMark;
        private Dictionary<int, int> dieMark;

        private int killProgress;
        private int highScoreProgress;
        private int dieProgress;
        private int gamePlayedProgress;

        private int idToUnlock;

        public event Action<string> OnAchievementCrossed;
        public event Action<int, RewardSystem.RewardUnlockType> UnlockReward;
        private RewardSystem.RewardUnlockType _type;

         private void Start()
        {
            _currentAchievementList = achievementScriptableObj.listOfAchievements;
            _type = RewardSystem.RewardUnlockType.ACHIEVEMENT;

            AddRespectiveMarks();
            RegisterServices();


        }

        private void AddRespectiveMarks()
        {
            foreach (AchievementScriptableObject _item in _currentAchievementList)
            {
                switch (_item.achievementTypes)
                {
                    case AchievementTypes.ENEMYKILLS:
                        enemyKillMark.Add(_item.value, _item.rewardIDToUnlock);
                        break;

                    case AchievementTypes.GAMESJOINED:
                        gamePlayedMark.Add(_item.value, _item.rewardIDToUnlock);
                        break;

                    case AchievementTypes.HIGHSCORE:
                        highScoreMark.Add(_item.value, _item.rewardIDToUnlock);
                        break;

                    case AchievementTypes.PLAYERDEATHS:
                        dieMark.Add(_item.value, _item.rewardIDToUnlock);
                        break;

                }
            }
        }
        private void RegisterServices()
        {
            GamesJoined += GamePlayedAchievements;
            GameApplication.Instance.GetService<IPlayerService>().EnemyKill += EnemyKillAchievements;
            GameApplication.Instance.GetService<IPlayerService>().PlayerDeath += DieAchievements;
            GameApplication.Instance.GetService<IPlayerService>().HighScoreUpdate += HighScoreAchievements;

        }

        public void InvokeGamesJoined(int _id, int _currentGamesValue)
        {
            GamesJoined.Invoke(_id, _currentGamesValue + 1);
        }
        public void DieAchievements(int _id, int _dieCalled)
        {
            idToUnlock = 1;

            if (_dieCalled >= dieMark[dieProgress])
            {
                GameApplication.Instance.GetService<IPlayerSaveService>().SetAchievementStatus(AchievementTypes.PLAYERDEATHS, _id, 1);
                dieProgress++;
            }

            AchievementStatus currentStatus = GameApplication.Instance.GetService<IPlayerSaveService>().GetAchievementStatus(AchievementTypes.PLAYERDEATHS, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + " Die " + dieMark.ToString() + " times");
                UnlockReward.Invoke(idToUnlock, _type);
            }



        }

        public void EnemyKillAchievements(int _id, int _enemyKilled)
        {
            
            if (_enemyKilled >= enemyKillMark[killProgress])
            {
                GameApplication.Instance.GetService<IPlayerSaveService>().SetAchievementStatus(AchievementTypes.ENEMYKILLS, _id, 1);
                killProgress++;
            }
            AchievementStatus currentStatus = GameApplication.Instance.GetService<IPlayerSaveService>().GetAchievementStatus(AchievementTypes.ENEMYKILLS, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + "Kill  " + enemyKillMark.ToString() + " Enemies!!");
                UnlockReward.Invoke(idToUnlock, _type);
            }
        }

        public void HighScoreAchievements(int _id, int _highScore)
        {
            idToUnlock = 3;
            if (_highScore >= highScoreMark[highScoreProgress])
            {
                GameApplication.Instance.GetService<IPlayerSaveService>().SetAchievementStatus(AchievementTypes.HIGHSCORE, _id, 1);
                highScoreProgress++;
            }
            AchievementStatus currentStatus = GameApplication.Instance.GetService<IPlayerSaveService>().GetAchievementStatus(AchievementTypes.HIGHSCORE, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + "Reach HighScore " + highScoreMark.ToString() + "!!");
                UnlockReward.Invoke(idToUnlock, _type);
            }
        }

        public void GamePlayedAchievements(int _id, int _gamesPlayed)
        {
            idToUnlock = 4;
            if (_gamesPlayed >= gamePlayedMark[gamePlayedProgress])
            {

                GameApplication.Instance.GetService<IPlayerSaveService>().SetAchievementStatus(AchievementTypes.GAMESJOINED, _id, 1);
                gamePlayedProgress++;
            }
            AchievementStatus currentStatus = GameApplication.Instance.GetService<IPlayerSaveService>().GetAchievementStatus(AchievementTypes.GAMESJOINED, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + "Play  " + gamePlayedMark.ToString() + " Games!!");
                UnlockReward?.Invoke(idToUnlock, _type);
            }
        }


    }
}
