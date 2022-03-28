using UnityEngine;

namespace PianoTilesEGC.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instanceClass;
        public static T Instance
        {
            get
            {
                if (instanceClass == null)
                {
                    instanceClass = (T)FindObjectOfType(typeof(T));
                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("Multiple instance of " + typeof(T).ToString());
                        return instanceClass;
                    }
                }

                return instanceClass;
            }
        }

        protected virtual void Awake()
        {
            if (instanceClass != null)
            {
                if (instanceClass != this)
                {
                    Debug.Log("Destroying duplicate " + gameObject.name + " from original: " + instanceClass.gameObject.name);
                    Destroy(this);
                    return;
                }
            }
        }
    }
}
