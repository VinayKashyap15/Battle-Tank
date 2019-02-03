using UnityEngine;
using Common;
using Player.UI;
using System.Collections.Generic;

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
            Debug.Log(_currenthighScore.ToString());
            return _currenthighScore;
        }


    }
}
