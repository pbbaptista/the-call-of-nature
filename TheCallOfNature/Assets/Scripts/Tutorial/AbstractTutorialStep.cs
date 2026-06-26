using UnityEngine;

public abstract class AbstractTutorialStep : MonoBehaviour
{
    public System.Action OnCompleted;

    internal void Complete()
    {
        OnCompleted.Invoke();
    }
}