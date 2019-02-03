using Interfaces;
using Player.UI;
using Enemy;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace SceneSpecific
{
    public class GameSceneController : SceneController
    {
        [SerializeField]
        private ScoreView scoreViewPrefab;
        private ScoreView scoreViewInstance;
        [SerializeField]
        private LayoutGroup parentLayoutGroup;
        private Vector3 currentViewPos;

        private List<ScoreView> listOfScoreView = new List<ScoreView>();

        protected override void OnIntialize()
        {
            base.OnIntialize();
            Player.PlayerService.Instance.OnStart();
            EnemyService.Instance.OnStart();
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
        }

        public override void SpawnPlayerUI(IController _currentPlayerControllerInstance)
        {
            scoreViewInstance = Instantiate(scoreViewPrefab, currentViewPos, Quaternion.identity);
            scoreViewInstance.gameObject.transform.SetParent(parentLayoutGroup.transform);
            currentViewPos += new Vector3(0, -5f, 0);

            scoreViewInstance.SetPlayerController(_currentPlayerControllerInstance);
            listOfScoreView.Add(scoreViewInstance);

        }

        public override void UpdateScoreView(IController _currentPlayerController, int _score,int _playerID)
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
                    item.UpdateScore(_score,_playerID);
                    return;
                }
            }
        }


    }
}