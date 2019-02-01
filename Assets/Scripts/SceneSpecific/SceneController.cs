using Common;
using UnityEngine;

namespace SceneSpecific
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        protected SceneScriptableObject _sceneScriptableObj;
        
    
        public virtual void OnClickPlay()
        {
            if (_sceneScriptableObj)
            {
                SceneLoader.Instance.OnClickPlay(_sceneScriptableObj.gameScene.name);
            }
            else
            {
                SceneLoader.Instance.OnClickPlay();
            }
        }

        public virtual void OnReturnHome()
        {
            SceneLoader.Instance.OnReturnHome();
        }

    }
}
