using UnityEngine;
using Weapons.Bullet;
using InputComponents;

namespace Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;
        private InputComponent currentInputComponent;

        public PlayerController(PlayerView playerViewInstance)
        {
            playerModel = new PlayerModel();            
            playerView = playerViewInstance;
            currentInputComponent = new InputComponent();
        }
        public PlayerController(PlayerView playerViewInstance, InputScriptabelObject _customInputScheme)
        {
            playerModel = new PlayerModel();
            playerView = playerViewInstance;
            currentInputComponent = new InputComponent(_customInputScheme);
        }
        public void Move(float h, float v)
        {
            playerView.MovePlayer(h, v, playerModel.GetSpeed());
        }
        public void DisplayPlayerStats()
        {
            Debug.Log("ID: " + playerModel.GetID().ToString() + "Player name:" + playerModel.GetName() + "Player Speed:" + playerModel.GetSpeed().ToString());
        }
        public void Fire()
        {
            var _bulletController = BulletService.Instance.SpawnBullet();
            float _bulletSpeed = _bulletController.GetBulletSpeed();

            Debug.Log("Current Speed:" + _bulletSpeed.ToString());

            playerView.OnFirePressed(_bulletController, _bulletSpeed);
        }
        public void RotatePlayer(float pitch)
        {
            playerView.RotatePlayer(pitch);
        }
    }
}