using System;
using Common;
using GameplayInterfaces;
using Player.UI;
using UnityEngine;
using UnityEngine.UI;

namespace SceneSpecific
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        protected SceneScriptableObject _sceneScriptableObj;
        

        private  void Awake()
        {
            OnIntialize();
        }

        protected virtual void OnIntialize()
        {
            ScoreManager.Instance.SetSceneController(this);
        }

        protected virtual void OnClickPlay()
        {
            SceneLoader.Instance.OnClickPlay(_sceneScriptableObj == null ? null: _sceneScriptableObj.gameScene.name);
        }

        protected virtual void OnReturnHome()
        {
            SceneLoader.Instance.OnReturnHome();
        }

        public virtual void SpawnPlayerUI(ICharacterController _playerController)
        {

        }

        public virtual void UpdateScoreView(ICharacterController _currentPlayerController, int _score, int _playerID)
        {
       
        }

        public virtual Vector3 FindSafePosition()
        {
            return Vector3.zero;
        }

    }
}
