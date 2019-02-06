using UnityEngine.SceneManagement;

namespace Common
{
    public class SceneLoader: SingletonBase<SceneLoader>
    {                
        public void OnClickPlay(string _gameScene=null)
        {
            SceneManager.LoadScene(_gameScene==null? "Game":_gameScene);           
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