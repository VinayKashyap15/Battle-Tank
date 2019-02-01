using Player;
using Player.UI;
using Enemy;
using UnityEngine;
using System.Collections.Generic;

namespace SceneSpecific
{
    public class GameSceneController : SceneController
    {
        [SerializeField]
        private ScoreView scoreViewPrefab;
        private ScoreView scoreViewInstance;
        [SerializeField]
        private Canvas parentCanvas;
        private Vector3 currentViewPos;

        private List<ScoreView> listOfScoreView = new List<ScoreView>();

        protected override void OnIntialize()
        {
            base.OnIntialize();
            PlayerService.Instance.OnStart();
            EnemyService.Instance.OnStart();
        }

        private void Start()
        {


            if (!scoreViewPrefab)
            {
                scoreViewPrefab = Resources.Load("PlayerText") as ScoreView;
            }
            currentViewPos = scoreViewPrefab.gameObject.transform.position;
           
            if (!parentCanvas)
            {
                Debug.Log("Parent not specified, using defaultParent");
                parentCanvas = GameObject.FindObjectOfType<Canvas>();
            }
        }

        public override void SpawnPlayerUI(PlayerController _currentPlayerControllerInstance)
        {
            scoreViewInstance = Instantiate(scoreViewPrefab, currentViewPos, Quaternion.identity);
            scoreViewInstance.gameObject.transform.SetParent(parentCanvas.transform, true);
            currentViewPos += new Vector3(0, -5f, 0);

            scoreViewInstance.SetPlayerController(_currentPlayerControllerInstance);
            listOfScoreView.Add(scoreViewInstance);

        }

        public override void UpdateScoreView(PlayerController _currentPlayerController, int _score)
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
                    item.UpdateScore(_score);
                    return;
                }
            }
        }
    }
}