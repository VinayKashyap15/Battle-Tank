using UnityEngine;

namespace RewardSystem
{
    [CreateAssetMenu(fileName = "NewRewardObject", menuName = "Custom Objects/Player/Reward", order = 0)]
    public class RewardScriptableObject: ScriptableObject
    {
        public int rewardID;
        
    }
}