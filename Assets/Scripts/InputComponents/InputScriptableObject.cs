using UnityEngine;

namespace InputComponents
{
    [CreateAssetMenu(fileName = "NewInputScheme", menuName = "Custom Objects/Input/Keyboard Input Scheme", order = 0)]
    public class InputScriptableObject : ScriptableObject
    {
        //for custom input schemes
        public KeyCode fireKey;
        public KeyCode moveForwardKey;
        public KeyCode moveBackwardKey;
        public KeyCode moveLeftKey;
        public KeyCode moveRightKey;

        public KeyCode pauseKey;
    }
}
