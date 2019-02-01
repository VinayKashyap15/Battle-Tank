using UnityEngine.SceneManagement;

namespace Common
{
    public class SceneLoader: SingletonBase<SceneLoader>
    {
        
        
        public void OnClickPlay(string _gameScene=null)
        {

            
            if (_gameScene!=null)
            {
                SceneManager.LoadScene(_gameScene);
            }
            else
            {
                SceneManager.LoadScene("Game");
            }
        }
        
        public void OnGameOver()
        {
            
            SceneManager.LoadScene("GameOver");
        }
        public void OnReturnHome()
        {
            SceneManager.LoadScene(0);
            
        }

    }
}