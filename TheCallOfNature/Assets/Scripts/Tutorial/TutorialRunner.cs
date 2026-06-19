using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    [SerializeField] private TutorialStep_Move stepMove;
    [SerializeField] private TutorialStep_ClickButton stepClick;
    [SerializeField] private TutorialStep_Dodge stepDodge;
    [SerializeField] private TutorialStep_ScarePeople stepScare;

    private ITutorialStep _current;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Begin(stepMove);

        stepMove.OnCompleted += () => Begin(stepClick);
        stepClick.OnCompleted += () => Begin(stepDodge);
        stepDodge.OnCompleted += () => Begin(stepScare);
    }

    private void Begin(ITutorialStep next)
    {
        _current?.Exit();
        _current = next;
        _current.Enter();

        // Each step should invoke a completion callback the runner sets.
        // (See below.)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
