using Delegate;
using UnityEngine;

public class FinishLevelBox : MonoBehaviour
{
    public static event GameEvent.ExitLevelBoxPass OnExitLevelBoxPass;
    private void OnTriggerEnter(Collider other)
    {
        OnExitLevelBoxPass?.Invoke();
    }
}
