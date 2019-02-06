using GameplayInterfaces;
using Player.UI;
using Enemy;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

namespace SceneSpecific
{
    public class GameSceneController : SceneController
    {
        [SerializeField]
        private ScoreView scoreViewPrefab;
        [SerializeField]
        private int maxThreatLevel;
        [SerializeField]
        private LayoutGroup parentLayoutGroup;
        [SerializeField]
        private float xDimension;
        [SerializeField]
        private float yDimension;
        [SerializeField]
        private int maxIterationLimit;

        private ScoreView scoreViewInstance;

        private List<EnemyController> enemyList = new List<EnemyController>();
        private List<ScoreView> listOfScoreView = new List<ScoreView>();
        private Dictionary<Vector3, int> threatLevel = new Dictionary<Vector3, int>();

        private Vector3 currentViewPos;
        private Vector3 spawnPos = Vector3.zero;

        protected override void OnIntialize()
        {           
            Player.PlayerService.Instance.OnStart(this);
            Enemy.EnemyService.Instance.OnStart();
        }
        private void Start()
        {
            if (!scoreViewPrefab)
            {
                scoreViewPrefab = Resources.Load("PlayerText") as ScoreView;
            }
            currentViewPos = scoreViewPrefab.gameObject.transform.position;

            if (!parentLayoutGroup)
            {
                Debug.Log("Parent not specified, using defaultParent");
                parentLayoutGroup = GameObject.FindObjectOfType<LayoutGroup>();
            }
            //StateMachineImplementation.StateMachineService.Instance.OnEnterGameScene+=StartServices;
            StartServices();
        }
        private void StartServices()
        {
            Player.PlayerService.Instance.OnStart(this);
            Enemy.EnemyService.Instance.OnStart();
        }
        public override void SpawnPlayerUI(ICharacterController _currentPlayerControllerInstance)
        {
            scoreViewInstance = Instantiate(scoreViewPrefab, currentViewPos, Quaternion.identity);
            scoreViewInstance.gameObject.transform.SetParent(parentLayoutGroup.transform);
            currentViewPos += new Vector3(0, -5f, 0);

            scoreViewInstance.SetPlayerController(_currentPlayerControllerInstance);
            listOfScoreView.Add(scoreViewInstance);

        }
        public override void UpdateScoreView(ICharacterController _currentPlayerController, int _score, int _playerID)
        {
            if (listOfScoreView.Count == 0)
            {
                Debug.Log("Score View not found");
                return;
            }

            foreach (ScoreView item in listOfScoreView)
            {
                if (item.GetPlayerController() == _currentPlayerController)
                {
                    item.UpdateScore(_score, _playerID);
                    return;
                }
            }
        }
        public override Vector3 FindSafePosition()
        {
            enemyList = EnemyService.Instance.GetEnemyList();
            List<Vector3> enemyPositions = new List<Vector3>();
            foreach (EnemyController i in enemyList)
            {
                enemyPositions.Add(i.GetPosition());
            }

            for (int i = 0; i < maxIterationLimit; i++)
            {
                spawnPos = GetRandomSpawnPos();
                if (!CheckForThreats(enemyPositions))
                {
                    return spawnPos;
                }
                else
                {
                    spawnPos = GetRandomSpawnPos();
                    if (i == maxIterationLimit)
                    {
                        spawnPos = GetMaxSafeLocation();
                    }
                }
            }
            return spawnPos;

        }
        private Vector3 GetMaxSafeLocation()
        {
            int _threat;
            threatLevel.TryGetValue(spawnPos, out _threat);
            Dictionary<Vector3, int>.ValueCollection value = threatLevel.Values;
            foreach (int _threatValue in value)
            {
                if (_threatValue < _threat)
                {
                    _threat = _threatValue;
                }
            }
            Vector3 _safestLocation = threatLevel.FirstOrDefault(x => x.Value == _threat).Key;

            return _safestLocation;
        }
        private bool CheckForThreats(List<Vector3> _enemyPositions)
        {
            int _currentThreatLevel = 0;

            foreach (Vector3 position in _enemyPositions)
            {
                if (!(Vector3.Distance(position, spawnPos) >= 3))
                {
                    _currentThreatLevel++;
                    if (_currentThreatLevel > maxThreatLevel)
                    {
                        threatLevel.Add(spawnPos, _currentThreatLevel);
                        return true;
                    }
                }
            }
            threatLevel.Add(spawnPos, _currentThreatLevel);
            return false;
        }
        private Vector3 GetRandomSpawnPos()
        {
            Vector3 _newPos = new Vector3(UnityEngine.Random.Range(0, xDimension), 0, UnityEngine.Random.Range(0, yDimension));
            if (threatLevel.ContainsKey(_newPos))
                _newPos = GetRandomSpawnPos();
            return _newPos;
        }

      
    }
}