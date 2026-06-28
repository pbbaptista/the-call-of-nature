using UnityEngine;
using UnityEngine.UIElements;

public class TutorialRunner : MonoBehaviour
{
    [SerializeField] private TutorialStep_Dodge stepDodge;
    [SerializeField] private TutorialStep_Move stepMove;
    [SerializeField] private TutorialStep_Poop stepPoop;
    [SerializeField] private TutorialStep_ScarePeople stepScare;
    public UIDocument uiTutorialDocument;

    public GameObject tutorialBg;

    private ITutorialStep _current;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialBg.SetActive(true);

        Begin(stepMove, "move");

        //stepMove.OnCompleted += () => Begin(stepPoop, "poop");
        //stepPoop.OnCompleted += () => Begin(stepDodge, "dodge");
        //stepDodge.OnCompleted += () => Begin(stepScare, "scare");

        // TODO: to go back to original order once all steps of the tutorial are implemented
        stepMove.OnCompleted += () => Begin(stepScare, "scare");
    }

    private void Begin(ITutorialStep next, string directiveName)
    {
        _current?.Exit();
        _current = next;
        _current.Enter(uiTutorialDocument, directiveName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
