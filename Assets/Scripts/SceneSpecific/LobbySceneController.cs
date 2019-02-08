using Lobby;
using RewardSystem;
using UnityEngine;
using UnityEngine.UI;

namespace SceneSpecific
{
    public class LobbySceneController:SceneController
    {
       
        [SerializeField]
        private LayoutGroup parentLayout;
        RewardScriptableObject _currentObj;
        private void Start() 
        {
            LobbyService.Instance.OnStart();
            LobbyService.Instance.SetSceneController(this);
            _currentObj=RewardService.Instance.GetListOfRewards();
           foreach(RewardData item in _currentObj.rewardList)
           {
               SpawnRewardPrefab(item.newReward);
           }
        }
        public void OnClickReward(RewardProperties _currentProperty)
        {
            if(_currentProperty.GetStatus()==RewardStatusEnum.UNLOCKED)
            {
                LobbyService.Instance.SavePlayerConfig(_currentProperty);
                
            }
        }

        public void SpawnRewardPrefab(RewardProperties _currProperty)
        {
            GameObject _currInstance=GameObject.Instantiate(_currProperty.gameObject) as GameObject;
            _currInstance.transform.SetParent(parentLayout.transform);
        }
       
    }
}