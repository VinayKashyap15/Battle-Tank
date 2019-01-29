using UnityEngine;
using System;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                DontDestroyOnLoad(instance);
            }
            else
            {
               // Debug.Log("null hai");
               // Destroy(instance);
            }
            return instance;
        }
    }
}