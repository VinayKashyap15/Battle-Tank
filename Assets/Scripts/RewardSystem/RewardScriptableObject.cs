using UnityEngine;
using System.Collections.Generic;

namespace RewardSystem
{
    [CreateAssetMenu(fileName = "NewRewardObject", menuName = "Custom Objects/Player/Reward", order = 0)]
    public class RewardScriptableObject : ScriptableObject
    {
        public List<RewardData> rewardList = new List<RewardData>();
       

    }
     [System.Serializable]
    public struct RewardData
    {
        public int id;
        public RewardStatusEnum currentStatus;
        public RewardProperties newReward;
        public RewardUnlockType unlockType;
    }
}