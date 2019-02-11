using UnityEngine;
using System.Collections.Generic;
namespace AchievementSystem
{
     [CreateAssetMenu(fileName = "NewAchievementList", menuName = "Custom Objects/Player/AchievementList", order = 0)]
    public class AchievementScriptableList:ScriptableObject
    {
        public List<AchievementScriptableObject> listOfAchievements= new List<AchievementScriptableObject>();
    }
}