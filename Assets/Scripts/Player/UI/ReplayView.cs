using UnityEngine;
using UnityEngine.UI;
using ServiceLocator;
using GameplayInterfaces;
using Common;
using System;

namespace Player.UI
{
    public class ReplayView : MonoBehaviour
    {
        [SerializeField]
        private Button exitBtn;
        [SerializeField]
        private Button _2xBtn;
        [SerializeField]
        private Button _halfxBtn;
        [SerializeField]
        private Button _pauseBtn;
        private void Start() 
        {            
            exitBtn.onClick.AddListener(()=>OnExitClicked());
            _2xBtn.onClick.AddListener(()=>On2xClicked());
            _halfxBtn.onClick.AddListener(()=>OnHalfxClicked());
           _pauseBtn.onClick.AddListener(()=>OnPauseClicked());
            
        }

        private void OnHalfxClicked()
        {
            Time.timeScale=0.5f;
        }

        public void OnExitClicked()
        {
            Time.timeScale=1f;
           GameApplication.Instance.GetService<ISceneLoader>().OnGameOver();

        }

        public void On2xClicked()
        {
            Time.timeScale=2.0f;
        }
        public void OnPauseClicked()
        {
           GameApplication.Instance.GetService<IStateMachineService>().SetGamePause();
        }
    }
}