
using UnityEngine;
using System;

namespace InputComponents
{
    /// <summary>
    /// Keyboard component for input
    /// </summary>
    public class KeyboardComponent : InputComponent
    {
        private KeyCode fireKey;

        public KeyboardComponent()
        {
            SetDefaultInputScheme();
        }

        private void SetDefaultInputScheme()
        {            
            fireKey=KeyCode.Space;
        }

        public override KeyCode GetFireInput()
        {
            return fireKey;
        }

    }
}
