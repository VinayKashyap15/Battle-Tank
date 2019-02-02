using UnityEngine;
using Interfaces;
using UnityEngine.UI;

namespace Player.UI
{
    public class ScoreView : MonoBehaviour
    {
        private IController myPlayerController;
        private Text scoreText;

        private void Start()
        {
            scoreText = gameObject.GetComponent<Text>();            
            scoreText.text = "Score : 0";
        }

        public void SetPlayerController(IController _playerControllerInstance)
        {
            myPlayerController = _playerControllerInstance;
        }

        public IController GetPlayerController()
        {
            return myPlayerController;
        }

        public void UpdateScore(int _score,int _playerID)
        {
            scoreText.text = " Player-"+_playerID.ToString()+" Score : " + _score.ToString();
        }

    }
}