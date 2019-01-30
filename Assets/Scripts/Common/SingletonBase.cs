using UnityEngine;
using System;

public class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
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
                Destroy(instance);
            }
            return instance;
        }
    }
    protected virtual void OnInitialize()
    { //start services
    }
}