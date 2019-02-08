using UnityEngine;
using UnityEngine.UI;
using Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IdleState idleState;
        private MovingState movingState;
        private FiringState firingState;
        private bool isFriendlyFire = true;
        private bool isActive = false;

        private Dictionary<PlayerState, bool> currentStateDictionary = new Dictionary<PlayerState, bool>();
       
        public PlayerController(PlayerView playerViewInstance, int _playerID, InputScriptableObject _customInputScheme = null, Material _rewardedMat = null)
        {
          
            playerModel = new PlayerModel();
            playerModel.SetID(_playerID);
            playerView = playerViewInstance;
           
           if(_rewardedMat!=null) 
           {SetMaterial(_rewardedMat);}
            if (_customInputScheme)
            { currentInputComponent = new CustomInputComponent(_customInputScheme, this); }
            else
            {
                currentInputComponent = new KeyboardComponent(this);
            }
            playerView.SetPlayerController(this);
            currentStateDictionary.Clear();
            CreateNewPlayerState();

            PlayerService.Instance.UpdatePlayer += UpdateCurrentPlayer;
        }
        private void UpdateCurrentPlayer()
        {
            
            foreach (PlayerState _state in currentStateDictionary.Keys)
            {

                currentStateDictionary.TryGetValue(_state, out isActive);
                if (isActive)
                {
                    _state.OnStateUpdate();
                    Debug.Log(" Active State :" + _state.ToString() + "for player " + GetID().ToString());
                }
                else
                {
                    _state.OnStateExit();
                }
            }
        }

        public void PauseGame()
        {
            currentInputComponent.isPaused = !currentInputComponent.isPaused;
            Debug.Log("isPaused for player " + GetID().ToString() + " " + currentInputComponent.isPaused);
        }

        private void CreateNewPlayerState()
        {
            if (idleState != null)
            {
                currentStateDictionary.Clear();
            }
            idleState = new IdleState(playerView);
            AddToStateDictionary(idleState, true);
            SetActiveInDictionary(idleState, true);
        }

        private void SetActiveInDictionary(PlayerState _currentState, bool _isActive)
        {
            if (currentStateDictionary.ContainsKey(_currentState))
            {
                currentStateDictionary[_currentState] = _isActive;
            }
        }
        private void AddToStateDictionary(PlayerState _state, bool _value)
        {
            currentStateDictionary.Add(_state, true);
        }

        public void CheckCollision(ITakeDamage _currentView, int damageValue)
        {
            if (_currentView.GetName() == "EnemyView")
            {
                EnemyService.Instance.SetDamagingPlayerID(GetID());
                _currentView.TakeDamage(damageValue);


            }
            else if (_currentView.GetName() == "PlayerView" && isFriendlyFire)
            {
                _currentView.TakeDamage(damageValue);
            }

        }
        public void Move(float h, float v)
        {
            SetActiveInDictionary(idleState, false);
            if (movingState == null)
            {
                movingState = new MovingState(playerView);
                AddToStateDictionary(movingState, true);
            }
            SetActiveInDictionary(movingState, true);

            currentState = movingState;
            playerView.MovePlayer(h, v, playerModel.GetSpeed());

        }
        public void PlayerIdle()
        {
            if (movingState != null)
                SetActiveInDictionary(movingState, false);

            else if (firingState != null)
                SetActiveInDictionary(firingState, false);

            SetActiveInDictionary(idleState, true);
        }
        public void Fire()
        {

            if (firingState == null)
            {
                firingState = new FiringState(playerView);
                AddToStateDictionary(firingState, true);
            }
            currentState = firingState;
            var _bulletController = BulletService.Instance.SpawnBullet(this);

            Vector3 firePos = playerView.GetMuzzlePosition();
            Quaternion fireRot = playerView.GetMuzzleRotation();
            Vector3 fireDirection = playerView.GetMuzzleDirection();
            _bulletController.FireBullet(firePos, fireRot, fireDirection);
        }

        public void SetFireState(bool _isFiring)
        {
            if (firingState != null)
                SetActiveInDictionary(firingState, _isFiring);
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
            if (_enemytype == EnemyType.BOSS)
            {
                _points = 50;
            }
            else
            {
                _points = 10;
            }
            int _newScore = playerView.UpdateMyScore(playerModel.GetCurrentScore(), _points);
            Debug.Log("Updated score for player :" + playerModel.GetID());

            playerModel.SetCurrentScore(_newScore);
            PlayerService.Instance.UpdateScoreView(this, _newScore, playerModel.GetID());

            int highScore = PlayerSaveData.Instance.GetHighScoreData(GetID());
            if (_newScore >= highScore)
            {
                PlayerSaveData.Instance.SetHighScoreData(GetID(), _newScore);
            }
            PlayerService.Instance.InvokeHighScoreAchievement(GetID(), highScore);

        }
        public int GetID()
        {
            return playerModel.GetID();
        }
        public void DestroySelf()
        {
            PlayerService.Instance.UpdatePlayer-=UpdateCurrentPlayer;
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

        public void SetMaterial(Material _mat)
        {
            playerView.SetMaterial(_mat);
        }
    }
}