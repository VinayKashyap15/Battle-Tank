using UnityEngine;
using System;

namespace InputComponents
{
    public class InputComponent : MonoBehaviour
    {
        private KeyCode fireKey;
        private InputComponent currentInputComponent;
        public InputComponent()
        {
            currentInputComponent = new KeyboardComponent();
        }

        public InputComponent(InputScriptabelObject _customInputScheme)
        {
            currentInputComponent = new CustomInputComponent(_customInputScheme);
        }

        public virtual KeyCode GetFireInput()
        {
            return fireKey;
        }
    }
}