using Loader;
using UnityEngine;

namespace SceneSpecific
{
    public class SceneController : MonoBehaviour
    {
        public virtual void OnClickPlay()
        {
            SceneLoader.Instance.OnClickPlay();
        }

        public virtual void OnReturnHome()
        {
            SceneLoader.Instance.OnReturnHome();
        }

    }
}
