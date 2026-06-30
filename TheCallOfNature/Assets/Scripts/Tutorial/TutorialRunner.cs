using UnityEngine;
using UnityEngine.UIElements;

public class TutorialRunner : MonoBehaviour
{
    [SerializeField] private TutorialStep_Dodge stepDodge;
    [SerializeField] private TutorialStep_Move stepMove;
    [SerializeField] private TutorialStep_Poop stepPoop;
    [SerializeField] private TutorialStep_ScarePeople stepScare;
    [SerializeField] private UIDocument uiTutorialDocument;
    [SerializeField] private UIDocument uiEndScreen;
    [SerializeField] private GameObject player;


    public GameObject tutorialBg;

    private ITutorialStep _current;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialBg.SetActive(true);

        Begin(stepScare, "scare", unlockMovement: false);

        // Begin(stepPoop, "scare", unlockMovement: true);

        //stepPoop.OnCompleted += () => Begin(stepScare, "scare", unlockMovement: false);
        //stepScare.OnCompleted += () => Begin(stepMove, "move", unlockMovement: true);
        //stepMove.OnCompleted += () => Begin(stepDodge, "dodge", unlockMovement: true);

        // TODO: to go back to original order once all steps of the tutorial are implemented
        stepScare.OnCompleted += () => Begin(stepMove, "move", unlockMovement: true);

        // on final step of tutorial, show end screen
        stepMove.OnCompleted += () => EndTutorial(finalStep: stepMove);
    }

    private void Begin(ITutorialStep next, string directiveName, bool unlockMovement)
    {
        _current?.Exit();
        _current = next;

        if (unlockMovement) {
            // by default, RigidBody2D component has both FreezeRotation and FreezePosition values
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        _current.Enter(uiTutorialDocument, directiveName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndTutorial(ITutorialStep finalStep)
    {
        finalStep.Exit();
        tutorialBg.SetActive(false);
        player.SetActive(false);

        uiEndScreen.rootVisualElement.Q<VisualElement>("EndScreenMenu").style.display = DisplayStyle.Flex;
    }
}
