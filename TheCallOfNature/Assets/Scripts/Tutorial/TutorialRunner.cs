using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    [SerializeField] private TutorialStep_Dodge stepDodge;
    [SerializeField] private TutorialStep_Move stepMove;
    [SerializeField] private TutorialStep_Poop stepPoop;
    [SerializeField] private TutorialStep_ScarePeople stepScare;

    public GameObject tutorialBg;

    private ITutorialStep _current;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialBg.SetActive(true);

        Begin(stepMove);

        stepMove.OnCompleted += () => Begin(stepPoop);
        stepPoop.OnCompleted += () => Begin(stepDodge);
        stepDodge.OnCompleted += () => Begin(stepScare);
    }

    private void Begin(ITutorialStep next)
    {
        _current?.Exit();
        _current = next;
        _current.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
