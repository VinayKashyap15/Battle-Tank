using UnityEngine;
using UnityEngine.UI;
using Enemy;
using PlayerStates;
using Weapons.Bullet;
using InputComponents;
using SaveFile;
using AchievementSystem;
using GameplayInterfaces;


namespace Player
{
    public class PlayerController : ICharacterController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;
        private InputComponent currentInputComponent;
        private PlayerState currentState;
        private bool isFriendlyFire = true;

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

            CreateNewPlayerState();
          }
          private void CreateNewPlayerState()
          {
              currentState=new IdleState();
          }
        public void CheckCollision(ITakeDamage _currentView, int damageValue)
        {
            if (_currentView.GetName()=="EnemyView")
            {
                EnemyService.Instance.SetDamagingPlayerID(GetID());
                _currentView.TakeDamage(damageValue);
              
               
            }
            else if (_currentView.GetName()=="PlayerView" && isFriendlyFire)
            {
                _currentView.TakeDamage(damageValue);
            }

        }
        public void Move(float h, float v)
        {
            currentState.OnStateExit(); 
            currentState=new MovingState();
            playerView.MovePlayer(h, v, playerModel.GetSpeed());
            
        }
        public void Fire()
        {
            currentState.OnStateExit();
            currentState=new FiringState();
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

        public void UpdateScore(int _enemyID, EnemyType _enemytype)
        {
            int _points;         
            if(_enemytype == EnemyType.BOSS){
                _points = 50;
            }else {
                _points = 10; }
            int _newScore = playerView.UpdateMyScore(playerModel.GetCurrentScore(),_points);
            Debug.Log("Updated score for player :" + playerModel.GetID());

            playerModel.SetCurrentScore(_newScore);
            PlayerService.Instance.UpdateScoreView(this, _newScore, playerModel.GetID());

            int highScore = PlayerSaveData.Instance.GetHighScoreData(GetID());
            if (_newScore >= highScore)
            {
                PlayerSaveData.Instance.SetHighScoreData(GetID(), _newScore);
            }
            PlayerService.Instance.InvokeHighScoreAchievement(GetID(),highScore);
            
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