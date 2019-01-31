using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InputComponents
{
    [CreateAssetMenu(fileName = "NewInputSchemeList", menuName = "Custom Objects/Input/Input Scheme List", order = 0)]
    public class InputScriptableObjectList : ScriptableObject
    {
        public List<InputScriptableObject> inputList = new List<InputScriptableObject>();
       
    }
}
