using UnityEngine;
using UnityEditor;

namespace Common
{
    public class MenuItems
    {
        [MenuItem("CustomTools/Clear PlayerPrefs")]
        private static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
