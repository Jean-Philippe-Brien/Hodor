using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError(Instance.name + " conflict with:\n" + this.name + " Managers Cannot be duplicated");
        }

        Instance = this;
    }
}
