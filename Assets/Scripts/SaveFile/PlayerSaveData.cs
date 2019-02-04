using UnityEngine;
using Common;
using Player.UI;
using System.Collections.Generic;
using System;

namespace SaveFile
{
    public class PlayerSaveData : SingletonBase<PlayerSaveData>
    {
        
        public void SetHighScoreData(int _playerID,int _highScore)
        {
          PlayerPrefs.SetInt("HighScore for Player"+_playerID.ToString(),_highScore);
          ScoreManager.Instance.PopulateHighScoreTexts("HighScore for Player" + _playerID.ToString()+ " : "+_highScore.ToString());
            
        }

        public int GetHighScoreData(int _playerID)
        {
            int _currenthighScore=PlayerPrefs.GetInt("HighScore for Player" + _playerID.ToString());
         
            return _currenthighScore;
        }

        public void OnHighScoreAchievementUnlocked(int _ID)
        {
            PlayerPrefs.SetInt("HighScore Achievement Status for Player"+_ID.ToString(), 1);
        }
        public int GetHighScoreAchievementStatus(int _ID)
        {
           return PlayerPrefs.GetInt("HighScore Achievement Status for Player" + _ID.ToString());
        }
    }
}
