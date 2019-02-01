using UnityEngine.SceneManagement;
using Common;

namespace Loader
{
    public class SceneLoader: SingletonBase<SceneLoader>
    {
        
        private void Start()
        {
            DisableGameplayServices();
        }
        public void OnClickPlay()
        {
            EnableGameplayServices();
            SceneManager.LoadScene("Game");
        }
        
        public void OnGameOver()
        {
            DisableGameplayServices();
            SceneManager.LoadScene("GameOver");
        }
        public void OnReturnHome()
        {
            SceneManager.LoadScene(0);
            
        }

        private void DisableGameplayServices()
        {
            Player.PlayerService.Instance.gameObject.SetActive(false);
            Enemy.EnemyService.Instance.gameObject.SetActive(false);
            InputComponents.InputManagerBase.Instance.gameObject.SetActive(false);
            Weapons.Bullet.BulletService.Instance.gameObject.SetActive(false);
        }
        private void EnableGameplayServices()
        {
            Player.PlayerService.Instance.gameObject.SetActive(true);
            Enemy.EnemyService.Instance.gameObject.SetActive(true);
            InputComponents.InputManagerBase.Instance.gameObject.SetActive(true);
            Weapons.Bullet.BulletService.Instance.gameObject.SetActive(true);
        }
    }
}