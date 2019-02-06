using UnityEngine;
using Common;
using Player;
using Player.UI;
using System;
using SaveFile;

namespace AchievementSystem
{
    public class AchievementManager : SingletonBase<AchievementManager>
    {
        [SerializeField]
        private AchievementScriptableObject achievementScriptableObj;
        public event Action<int, int> GamesJoined;

        private int highScoreMark;
        private int enemyKillMark;
        private int gamePlayedMark;
        private int dieMark;

        public event Action<string> OnAchievementCrossed;

       private void Start()
       {
            enemyKillMark =achievementScriptableObj.enemyKills;
            highScoreMark = achievementScriptableObj.highScore;
            gamePlayedMark = achievementScriptableObj.gamesPlayed;
            dieMark = achievementScriptableObj.dieTimes;
             RegisterServices();
           
            
       }
          private void RegisterServices()
        {
             GamesJoined += GamePlayedAchievements;
            PlayerService.Instance.EnemyKill +=EnemyKillAchievements;
            PlayerService.Instance.PlayerDeath += DieAchievements;
            PlayerService.Instance.HighScoreUpdate += HighScoreAchievements;
            
           
        }

            public void InvokeGamesJoined(int _id, int _currentGamesValue)
            {
                 GamesJoined.Invoke(_id,_currentGamesValue+1);
            }
        public void DieAchievements(int _id, int _dieCalled)
        {
            
            if(_dieCalled>=dieMark)
            {
                PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.PLAYERDEATHS,_id,1);
            }

            AchievementStatus currentStatus=  PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.PLAYERDEATHS,_id);
            if(currentStatus==AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString()+" Die "+dieMark.ToString()+" times");
            }
        }

        public void EnemyKillAchievements(int _id, int _enemyKilled)
        {
            if (_enemyKilled >= enemyKillMark)
            {
                PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.ENEMYKILLS, _id, 1);
            }
            AchievementStatus currentStatus = PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.ENEMYKILLS, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player"+_id.ToString() +"Kill  " + enemyKillMark.ToString() + " Enemies!!");
            }
        }

        public void HighScoreAchievements(int _id, int _highScore)
        {
            if(_highScore>=highScoreMark)
            {
                PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.HIGHSCORE,_id,1);
            }
            AchievementStatus currentStatus = PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.HIGHSCORE, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString()+"Reach HighScore " + highScoreMark.ToString() + "!!");
            }
        }

        public void GamePlayedAchievements(int _id, int _gamesPlayed)
        {
            if(_gamesPlayed>=gamePlayedMark)
            {
                PlayerSaveData.Instance.SetAchievementStatus(AchievementTypes.GAMESJOINED, _id, 1);
            }
            AchievementStatus currentStatus = PlayerSaveData.Instance.GetAchievementStatus(AchievementTypes.GAMESJOINED, _id);
            if (currentStatus == AchievementStatus.FINISHED)
            {
                OnAchievementCrossed.Invoke("Achievement Unlocked for player" + _id.ToString()+"Play  " + gamePlayedMark.ToString() + " Games!!");
            }
        }

        
    }
}
