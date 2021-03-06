﻿using System;
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
        [SerializeField]
        private LayoutGroup _currentCanvasParent;
        private  void Start()
        {
            OnIntialize();
            GameApplication.Instance.GetService<ISceneLoader>().OnStart();
        }
        private void Update() {
            GameApplication.Instance.GetService<ISceneLoader>().OnUpdate();
            
        }
        protected virtual void OnIntialize()
        {
            GameApplication.Instance.GetService<IScoreManager>().SetSceneController(this);
        }
        public virtual void OnClickStart()
        {
           GameApplication.Instance.GetService<ISceneLoader>().OnClickStart(_sceneScriptableObj == null ? "Start": _sceneScriptableObj.gameScene.name);
        }

        public virtual void OnClickPlay()
        {
           GameApplication.Instance.GetService<ISceneLoader>().OnClickPlay(_sceneScriptableObj == null ? "Game": _sceneScriptableObj.startScene.name);
        }

        public virtual Transform GetCanvasParent()
        {
            return _currentCanvasParent.transform;
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
