using UnityEngine.UI;
using ServiceLocator;
using GameplayInterfaces;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Player.UI;

namespace SceneSpecific
{
    public class GameOverController : SceneController
    {
        [SerializeField]
        private Text highScoreTextPrefab;
        [SerializeField]
        private LayoutGroup layoutGroup;

        private Text highScoreTextInstance;

        private void Start()
        {
            if (!highScoreTextPrefab)
            {
                highScoreTextPrefab = Resources.Load("HighScoreText") as Text;
            }
            if (!layoutGroup)
                Debug.Log("Layout group not specified");

            PopulateVerticalGroup();
        }

        private void PopulateVerticalGroup()
        {
            List<string> textList=GameApplication.Instance.GetService<IScoreManager>().GetHighScoreTextList();
            for (int i = 0; i < textList.Count; i++)
            {
                SpawnText(textList.ElementAt(i));
            }
        }

        private void SpawnText(string _text)
        {
            highScoreTextInstance = GameObject.Instantiate(highScoreTextPrefab) as Text;
            highScoreTextInstance.text = _text;
            highScoreTextInstance.transform.SetParent(layoutGroup.transform);
        }

        public override Transform GetCanvasParent()
        {
            return layoutGroup.transform;
        }
    }
}
