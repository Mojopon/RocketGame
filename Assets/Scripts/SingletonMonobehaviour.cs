using UnityEngine;
using System.Collections;

public class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (!instance)
                    return null;
            }

            return instance;
        }
    }
}
