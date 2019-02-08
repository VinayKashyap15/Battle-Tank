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
        private  void Start()
        {
            OnIntialize();
        }

        protected virtual void OnIntialize()
        {
            ScoreManager.Instance.SetSceneController(this);
        }
        public virtual void OnClickStart()
        {
            SceneLoader.Instance.OnClickStart(_sceneScriptableObj == null ? "Start": _sceneScriptableObj.gameScene.name);
        }

        public virtual void OnClickPlay()
        {
            SceneLoader.Instance.OnClickPlay(_sceneScriptableObj == null ? "Game": _sceneScriptableObj.startScene.name);
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
