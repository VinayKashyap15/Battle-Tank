using ServiceLocator;
using GameplayInterfaces;
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
            GameApplication.Instance.GetService<ILobbyService>().OnStart();
            GameApplication.Instance.GetService<ILobbyService>().SetSceneController(this);
            _currentObj=GameApplication.Instance.GetService<IRewardService>().GetListOfRewards();
           foreach(RewardData item in _currentObj.rewardList)
           {
               SpawnRewardPrefab(item.newReward);
           }
        }
        public void OnClickReward(RewardProperties _currentProperty)
        {
            if(_currentProperty.GetStatus()==RewardStatusEnum.UNLOCKED)
            {
                GameApplication.Instance.GetService<ILobbyService>().SavePlayerConfig(_currentProperty);
                
            }
        }

        public void SpawnRewardPrefab(RewardProperties _currProperty)
        {
            GameObject _currInstance=GameObject.Instantiate(_currProperty.gameObject) as GameObject;
            _currInstance.transform.SetParent(parentLayout.transform);
        }
       
    }
}