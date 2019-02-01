using UnityEngine;
using UnityEngine.UI;
using Weapons.Bullet;
using InputComponents;

namespace Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;
        private InputComponent currentInputComponent;


        public PlayerController(PlayerView playerViewInstance, int _playerID, InputScriptableObject _customInputScheme = null)
        {
            playerModel = new PlayerModel();
            playerModel.SetID(_playerID);
            playerView = playerViewInstance;
            if (_customInputScheme)
            { currentInputComponent = new CustomInputComponent(_customInputScheme, this); }
            else
            {
                currentInputComponent = new KeyboardComponent(this);
            }
            playerView.SetPlayerController(this);

        }

        public void Move(float h, float v)
        {
            playerView.MovePlayer(h, v, playerModel.GetSpeed());
        }
        public void Fire()
        {
            var _bulletController = BulletService.Instance.SpawnBullet(this);

            Vector3 firePos = playerView.GetMuzzlePosition();
            Quaternion fireRot = playerView.GetMuzzleRotation();
            Vector3 fireDirection = playerView.GetMuzzleDirection();
            _bulletController.FireBullet(firePos, fireRot, fireDirection);
        }
        public void RotatePlayer(float pitch)
        {
            playerView.RotatePlayer(pitch);
        }

        public InputComponent GetInputComponent()
        {
            return currentInputComponent;
        }

        public void UpdateScore()
        {
            int _newScore = playerView.UpdateMyScore(playerModel.GetCurrentScore());
            Debug.Log("Updated score for player :" + playerModel.GetID());
            
            playerModel.SetCurrentScore(_newScore);
            PlayerService.Instance.UpdateScoreView(this,_newScore);


        }

        public void DestroySelf()
        {
            playerModel = null;
        }
    }
}