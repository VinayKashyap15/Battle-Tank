using UnityEngine;

namespace InputComponents
{
    [CreateAssetMenu(fileName = "NewInputScheme", menuName = "Custom Objects/Input/Input Scheme", order = 0)]
    public class InputScriptabelObject : ScriptableObject
    {
        //for custom input schemes
        public KeyCode fireKey;
    }
}
