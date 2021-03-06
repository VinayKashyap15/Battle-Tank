﻿using UnityEngine;
using Common;
using ServiceLocator;
using GameplayInterfaces;
using Player.UI;
using System;
using AchievementSystem;

namespace SaveFile
{
    public class PlayerSaveData : IPlayerSaveService
    {
        private DataSaveTypeEnum _currentSaveType;
        private ISaveData _currentSaveMethod= new SaveInPlayerPrefs();
        

        public void SetInt(string _dataToSave,int _id,int _value)
        {
            _currentSaveMethod.SaveInt(_dataToSave,_id,_value);
        }
        public int GetInt(string _dataToSave,int _id)
        {
            return _currentSaveMethod.GetInt(_dataToSave,_id);
        }

        #region  OldCodeStuff
        public void SetHighScoreData(int _playerID, int _highScore)
        {
            PlayerPrefs.SetInt("HighScore for Player" + _playerID.ToString(), _highScore);
            GameApplication.Instance.GetService<IScoreManager>().PopulateHighScoreTexts("HighScore for Player" + _playerID.ToString() + " : " + _highScore.ToString());

        }
        public int GetHighScoreData(int _playerID)
        {
            int _currenthighScore = PlayerPrefs.GetInt("HighScore for Player" + _playerID.ToString());

            return _currenthighScore;
        }
        public void SetDieMark(int _id, int _numberOfTimesFunctionCalled)
        {
            if (!PlayerPrefs.HasKey("Player " + _id.ToString() + " Deaths"))
            {
                PlayerPrefs.SetInt("Player " + _id.ToString() + " Deaths", 1);
            }
            else
            {
                int _currentDeaths = PlayerPrefs.GetInt("Player " + _id.ToString() + " Deaths");
                _currentDeaths++;
                PlayerPrefs.SetInt("Player " + _id.ToString() + " Deaths", _currentDeaths);
            }
        }
        public void SetEnemyKillData(int _id, int _enemyKill)
        {
            PlayerPrefs.SetInt("EnemyKills for Player" + _id.ToString(), _enemyKill);

        }
        public int GetEnemyKillData(int _id)
        {
            return PlayerPrefs.GetInt("EnemyKills for Player" + _id.ToString());
        }

        public void SetGamesPlayedData(int _id, int _gamesPlayed)
        {
            PlayerPrefs.SetInt("GamesPlayed Player" + _id.ToString(), _gamesPlayed);

        }
        public int GetGamesPlayedData(int _id)
        {
            return PlayerPrefs.GetInt("GamesPlayed Player" + _id.ToString());
        }

        public AchievementStatus GetAchievementStatus(AchievementTypes _type, int _id)
        {
            int _statusInt = PlayerPrefs.GetInt("Player" + _id.ToString() + _type.ToString());
            if (_statusInt == 1)
            {
                return AchievementStatus.FINISHED;
            }
            else
            {
                return AchievementStatus.UNFINISHED;
            }

        }
        public void SetAchievementStatus(AchievementTypes _type, int _id, int _status)
        {
            PlayerPrefs.SetInt("Player" + _id.ToString() + _type.ToString(), _status);
        }

      
        #endregion
    }
}
