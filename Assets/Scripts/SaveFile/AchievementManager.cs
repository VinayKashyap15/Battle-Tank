using UnityEngine;
using Common;
using System;

namespace SaveFile
{
    public class AchievementManager : SingletonBase<AchievementManager>
    {
        [SerializeField]
        private AchievementScriptableObject achievementScriptableObj;

        private int highScoreMark;
        private int enemyKillMark;
        private int gamePlayedMark;
        public event Action<string> OnAchievementCrossed;

       private void Start()
       {
            enemyKillMark =achievementScriptableObj.enemyKills;
            highScoreMark = achievementScriptableObj.highScore;
            gamePlayedMark = achievementScriptableObj.gamesPlayed;

            OnAchievementCrossed += Player.UI.ScoreManager.Instance.OnAchievementUnlocked;
       }

        public void AchievementUnlocked(string _achievement)
        {
            OnAchievementCrossed.Invoke(_achievement);
        }
        public int GetHighScore()
        {
            return highScoreMark;
        }

        public int GetKillCount()
        {
            return enemyKillMark;
        }
        public int GetGamesPlayed()
        {
            return gamePlayedMark;
        }
    }
}
