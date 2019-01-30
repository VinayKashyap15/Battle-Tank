using UnityEngine;
using Weapons.Bullet;

namespace Player
{
    public class PlayerController
    {
        PlayerView playerView;
        PlayerModel playerModel;

        public PlayerController(PlayerView playerViewInstance)
        {
            playerModel = new PlayerModel();
            playerView = playerViewInstance;
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
            
            Vector3 firePos=playerView.GetMuzzlePosition();
            Quaternion fireRot= playerView.GetMuzzleRotation();
            Vector3 fireDirection = playerView.GetMuzzleDirection();
            _bulletController.FireBullet(firePos, fireRot, fireDirection); 
        }

        public void RotatePlayer(float pitch)
        {
            playerView.RotatePlayer(pitch);
        }        
    }
}