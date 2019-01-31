using UnityEngine;
using Player;
using Enemy;
using UnityEngine.UI;

namespace Common
{
    public class ScoreManager : SingletonBase<ScoreManager>
    {
        public void UpdateScore(PlayerController _playerControllerToUpdate)
        {
            _playerControllerToUpdate.UpdateScore();
            
        }
    }
}
