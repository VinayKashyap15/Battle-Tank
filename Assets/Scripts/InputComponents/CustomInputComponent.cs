using UnityEngine;

namespace InputComponents
{
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
