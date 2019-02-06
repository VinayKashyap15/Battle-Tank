using UnityEngine;
using GameplayInterfaces;
using UnityEngine.UI;

namespace Player.UI
{
    public class ScoreView : MonoBehaviour
    {
        private ICharacterController myPlayerController;
        private Text scoreText;

        private void Start()
        {
            scoreText = gameObject.GetComponent<Text>();            
            scoreText.text = "Score : 0";
        }

        public void SetPlayerController(ICharacterController _playerControllerInstance)
        {
            myPlayerController = _playerControllerInstance;
        }

        public ICharacterController GetPlayerController()
        {
            return myPlayerController;
        }

        public void UpdateScore(int _score,int _playerID)
        {
            scoreText.text = " Player-"+_playerID.ToString()+" Score : " + _score.ToString();
        }

    }
}