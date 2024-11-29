using UnityEngine;

namespace GameCore
{
    public abstract class BaseManager<T> : MonoBehaviour where T : BaseManager<T>
    {
        public static T Instance;
        
        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"{Instance.gameObject.name} conflict with: {gameObject.name} Managers Cannot be duplicated");
                Destroy(Instance.gameObject);
            }

            Instance = (T) this;
        }
    }
}
