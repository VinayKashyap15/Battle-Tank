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
        public event Action OnAchievementCrossed;

       private void Start()
       {
            enemyKillMark =achievementScriptableObj.enemyKills;
            highScoreMark = achievementScriptableObj.highScore;
            gamePlayedMark = achievementScriptableObj.gamesPlayed;
       }


    }
}
