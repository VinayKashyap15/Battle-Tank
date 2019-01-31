using UnityEngine;

namespace InputComponents
{
    /// <summary>
    /// custom input taken from the scriptable object 
    /// </summary>
    class CustomInputComponent : InputComponent
    {
        private KeyCode fireKey;

        public CustomInputComponent(InputScriptabelObject _customInputScheme)
        {
            fireKey=_customInputScheme.fireKey;
        }

        public override KeyCode GetFireInput()
        {
            return fireKey;
        }
    }
}
