using UnityEngine;
using UnityEngine.UI;
using Weapons.Bullet;
using InputComponents;
using SaveFile;
using Interfaces;


namespace Player
{
    public class PlayerController : IController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;
        private InputComponent currentInputComponent;
        private bool isFriendlyFire = true;
        private int highScoreAchievement;
        private int enemyKillAchievement;
        private int gamePlayedAchievement;

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
            highScoreAchievement = AchievementManager.Instance.GetHighScore();
            enemyKillAchievement = AchievementManager.Instance.GetKillCount();
            gamePlayedAchievement = AchievementManager.Instance.GetGamesPlayed();
          }
        public void CheckCollision(GameObject _gameObject, int damageValue)
        {
            if (_gameObject.GetComponent<Enemy.EnemyView>())
            {
                _gameObject.GetComponent<Enemy.EnemyView>().TakeDamage(damageValue);
                UpdateScore();
            }
            else if (_gameObject.GetComponent<PlayerView>() && isFriendlyFire)
            {
                _gameObject.GetComponent<PlayerView>().TakeDamage(damageValue);
            }

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
            PlayerService.Instance.UpdateScoreView(this, _newScore, playerModel.GetID());

            int highScore = PlayerService.Instance.GetHighScore(this);
            if (_newScore >= highScore)
            {
                PlayerService.Instance.SetHighScore(this, _newScore);
            }
            if (PlayerSaveData.Instance.GetHighScoreAchievementStatus(playerModel.GetID()) == 0)
            {
                if (highScore >= highScoreAchievement)
                {
                    PlayerService.Instance.OnAchievementUnlocked("Achievement Unlocked for player " + playerModel.GetID() + "SCORE:" + highScoreAchievement.ToString() + "!!");
                    PlayerSaveData.Instance.OnHighScoreAchievementUnlocked(playerModel.GetID());
                }
            }
        }

        public int GetID()
        {
            return playerModel.GetID();
        }
        public void DestroySelf()
        {
            playerModel = null;
        }
        public void TakeDamage(int _damage)
        {
            playerModel.SetHealth(playerModel.GetHealth() - _damage);
            if (playerModel.GetHealth() <= 0)
            {
                Debug.Log("player dead");
                playerView.DestoySelf();
            }
        }
        public void RegenerateHealth()
        {
            playerModel.SetHealth(100);
        }
        
    }
}