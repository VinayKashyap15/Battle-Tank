using UnityEngine;
namespace SaveFile
{
    [CreateAssetMenu(fileName = "NewAchievementData", menuName = "Custom Objects/Player/Achievement", order = 0)]
    public class AchievementScriptableObject:ScriptableObject
    {
        public int highScore;
        public int enemyKills;
        public int gamesPlayed;
    }
}
