using AchievementSystem;
using UnityEngine;
using RewardSystem;
using System.Collections.Generic;
using Common;
using System;
using System.Linq;

namespace RewardSystem
{

    public class RewardService : SingletonBase<RewardService>
    {
        public struct CurrentRewardData
        {
            public int currentRewardID;
            public RewardUnlockType _currentUnlockType;
            public RewardProperties _currentRewardPrefab;
            public RewardStatusEnum _currentRewardStatus;
        }
        [SerializeField]
        private RewardScriptableObject _rewardScriptableObjList;
        private List<CurrentRewardData> rewardDataList = new List<CurrentRewardData>();
        private void Start()
        {
            foreach (RewardData _obj in _rewardScriptableObjList.rewardList)
            {
                PopulateRewardDataList(_obj);
            }
            AchievementManager.Instance.UnlockReward+=OnRewardUnlocked;
        }

        private void PopulateRewardDataList(RewardData _obj)
        {
            CurrentRewardData _currentRewardData;
            _currentRewardData._currentRewardStatus = _obj.currentStatus;
            _currentRewardData.currentRewardID = _obj.id;
            _currentRewardData._currentRewardPrefab = _obj.newReward;
            _currentRewardData._currentUnlockType = _obj.unlockType;
            rewardDataList.Add(_currentRewardData);
        }

        public void OnRewardUnlocked(int _id, RewardUnlockType _type)
        {
            foreach (CurrentRewardData item in rewardDataList)
            {
                if (item._currentUnlockType != _type)
                {
                    continue;
                }
                else if (item.currentRewardID == _id)
                {
                    if (item._currentRewardStatus == RewardStatusEnum.LOCKED)
                    {
                        int currentIndex=rewardDataList.IndexOf(item);
                        var currentItem=rewardDataList.ElementAt(currentIndex);
                        currentItem._currentRewardStatus= RewardStatusEnum.UNLOCKED;
                        rewardDataList[currentIndex]=currentItem;                       
                        item._currentRewardPrefab.SetStatus(RewardStatusEnum.UNLOCKED);

                     
                    }
                }
            }

        }

        public RewardScriptableObject GetListOfRewards()
        {
            return _rewardScriptableObjList;
        }
    }
}