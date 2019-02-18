using System;
using Common;
using UnityEngine;
using ServiceLocator;
using GameplayInterfaces;
using Lobby;
using UnityEngine.UI;

namespace RewardSystem
{

    public class RewardProperties : MonoBehaviour
    {
        [SerializeField]
        private Material _mat;

        GameObject faderSphere;
        [SerializeField]
        private RewardStatusEnum _currentStatus;

        private PlayerConfigurationData _currentData;
        private Button _button;

        private void Start()
        {
            SetConfigData();
            if (_currentStatus == RewardStatusEnum.LOCKED)
            {
                gameObject.GetComponentInChildren<Image>().color = Color.grey;
            }
            else
            {
                gameObject.GetComponentInChildren<Image>().color = Color.white;
            }

            _button = gameObject.GetComponentInChildren<Button>();
            _button.onClick.AddListener(() => GameApplication.Instance.GetService<ILobbyService>().OnButtonClicked(this));
        }
        private void SetConfigData()
        {
            _currentData.material = _mat;
        }

        public RewardStatusEnum GetStatus()
        {
            //throw new NotImplementedException();
            return _currentStatus;
        }

        public void SetStatus(RewardStatusEnum _newStatus)
        {
            _currentStatus = _newStatus;
            CheckForUnlock();
        }

        private void CheckForUnlock()
        {
            if (_currentStatus == RewardStatusEnum.UNLOCKED)
            {
                gameObject.GetComponentInChildren<Image>().color = Color.white;
                SetConfigData();
            }
            else
            {
                gameObject.GetComponentInChildren<Image>().color = Color.grey;
            }
        }

        public PlayerConfigurationData GetConfigData()
        {
            return _currentData;
        }
        public Material GetMaterialFromData()
        {
            return _currentData.material;
        }

   
    }
}