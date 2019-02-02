using UnityEngine;
using Common;
namespace SaveFile
{
    public class PlayerSaveData : SingletonBase<PlayerSaveData>
    {
        
        
        public void SetHighScoreData(int _playerID,int _highScore)
        {
            PlayerPrefs.SetInt("HighScore for Player"+_playerID.ToString(),_highScore);
        }

        public int GetHighScoreData(int _playerID)
        {
            int _currenthighScore=PlayerPrefs.GetInt("HighScore for Player" + _playerID.ToString());
            return _currenthighScore;
        }
    }
}
