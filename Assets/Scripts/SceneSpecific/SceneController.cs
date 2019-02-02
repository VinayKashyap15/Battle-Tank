using System;
using Common;
using Interfaces;
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
        private Text highScoreText;

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

        public virtual void SpawnPlayerUI(IController _playerController)
        {

        }

        public virtual void UpdateScoreView(IController _currentPlayerController, int _score, int _playerID)
        {

        }

    }
}
