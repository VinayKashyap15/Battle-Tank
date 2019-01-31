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
            currentInputComponent = new KeyboardComponent();
        }
        public PlayerController(PlayerView playerViewInstance, InputScriptabelObject _customInputScheme)
        {
            playerModel = new PlayerModel();
            playerView = playerViewInstance;
            currentInputComponent = new CustomInputComponent(_customInputScheme);

        }

        public void Move(float h, float v)
        {
            playerView.MovePlayer(h, v, playerModel.GetSpeed());
        }
        public void Fire()
        {
            var _bulletController = BulletService.Instance.SpawnBullet();

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
    }
}