using UnityEngine;
namespace Common
{
    public class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}