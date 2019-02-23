using UnityEngine;
namespace AchievementSystem
{
    [CreateAssetMenu(fileName = "NewAchievementData", menuName = "Custom Objects/Player/Achievement", order = 1)]
    public class AchievementScriptableObject:ScriptableObject
    {
        public int value;
        public int rewardIDToUnlock;
        public AchievementTypes achievementTypes;
        public AchievementStatus achievementStatus;
    }
}
