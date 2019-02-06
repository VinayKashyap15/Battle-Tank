using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneSpecific
{
    [CreateAssetMenu(fileName = "NewGameScene", menuName = "Custom Objects/Scene", order = 0)]
    public class SceneScriptableObject : ScriptableObject
    {
        public Object gameScene;
        public Object startScene;
    }
}
