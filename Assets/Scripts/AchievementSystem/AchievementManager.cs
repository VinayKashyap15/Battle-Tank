using UnityEngine;
using Common;
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
        private int idToUnlock;

        public event Action<string> OnAchievementCrossed;
        public event Action<int, RewardSystem.RewardUnlockType> UnlockReward;
        private RewardSystem.RewardUnlockType _type;

        // private void Start()
        // {
        //     _currentAchievementList = achievementScriptableObj.listOfAchievements;
        //     _type = RewardSystem.RewardUnlockType.ACHIEVEMENT;

        //     AddRespectiveMarks();
        //     RegisterServices();


        // }

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
            PlayerService.Instance.EnemyKill += EnemyKillAchievements;
            PlayerService.Instance.PlayerDeath += DieAchievements;
            PlayerService.Instance.HighScoreUpdate += HighScoreAchievements;

        }

        // public void InvokeGamesJoined(int _id, int _currentGamesValue)
        // {
        //     GamesJoined.Invoke(_id, _currentGamesValue + 1);
        // }
        public void DieAchievements(int _id, int _dieCalled)
        {
            //idToUnlock = 1;

            // if (_dieCalled >= dieMark)
            // {
            //     PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.PLAYERDEATHS, _id, 1);
            // }

            // AchievementStatus currentStatus = PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.PLAYERDEATHS, _id);
            // if (currentStatus == AchievementStatus.FINISHED)
            // {
            //     OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + " Die " + dieMark.ToString() + " times");
            //     UnlockReward.Invoke(idToUnlock, _type);
            // }



        }

        public void EnemyKillAchievements(int _id, int _enemyKilled)
        {
            idToUnlock = 2;
            // if (_enemyKilled >= enemyKillMark)
            // {
            //     PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.ENEMYKILLS, _id, 1);
            // }
            AchievementStatus currentStatus = PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.ENEMYKILLS, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + "Kill  " + enemyKillMark.ToString() + " Enemies!!");
                UnlockReward.Invoke(idToUnlock, _type);
            }
        }

        public void HighScoreAchievements(int _id, int _highScore)
        {
            idToUnlock = 3;
            // if (_highScore >= highScoreMark)
            // {
            //     PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.HIGHSCORE, _id, 1);
            // }
            AchievementStatus currentStatus = PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.HIGHSCORE, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + "Reach HighScore " + highScoreMark.ToString() + "!!");
                UnlockReward.Invoke(idToUnlock, _type);
            }
        }

        public void GamePlayedAchievements(int _id, int _gamesPlayed)
        {
            idToUnlock = 4;
            // if (_gamesPlayed >= gamePlayedMark)
            // {
            //     PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.GAMESJOINED, _id, 1);
            // }
            AchievementStatus currentStatus = PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.GAMESJOINED, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString() + "Play  " + gamePlayedMark.ToString() + " Games!!");
                UnlockReward?.Invoke(idToUnlock, _type);
            }
        }


    }
}
