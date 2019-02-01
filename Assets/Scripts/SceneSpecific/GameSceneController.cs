using Loader;
using UnityEngine;

namespace SceneSpecific
{
    public class GameSceneController : SceneController
    {
        private void Awake()
        {
            Player.PlayerService.Instance.OnStart();
            Enemy.EnemyService.Instance.OnStart();
        }

    }
}