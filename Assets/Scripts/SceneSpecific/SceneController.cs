using System;
using Common;
using ServiceLocator;
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
           GameApplication.Instance.GetService<ISceneLoader>().OnClickStart(_sceneScriptableObj == null ? "Start": _sceneScriptableObj.gameScene.name);
        }

        public virtual void OnClickPlay()
        {
           GameApplication.Instance.GetService<ISceneLoader>().OnClickPlay(_sceneScriptableObj == null ? "Game": _sceneScriptableObj.startScene.name);
        }

        public virtual void SpawnReplayUI()
        {
            
        }

        protected virtual void OnReturnHome()
        {
           GameApplication.Instance.GetService<ISceneLoader>().OnReturnHome();
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
