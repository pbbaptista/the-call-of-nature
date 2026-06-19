using UnityEngine;

public abstract class AbstractTutorialStep : MonoBehaviour
{
    public System.Action OnCompleted;

    private void Complete()
    {
        OnCompleted.Invoke();
    }
}