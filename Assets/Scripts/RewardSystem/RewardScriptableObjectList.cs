using UnityEngine;
using System.Collections.Generic;

namespace RewardSystem
{
    [CreateAssetMenu(fileName = "NewRewardObject", menuName = "Custom Objects/Player/Reward List", order = 0)]
    public class RewardScriptableObjectList: ScriptableObject
    {
       public List<RewardScriptableObject> rewardScriptableObject= new List<RewardScriptableObject>();
        
    }
}