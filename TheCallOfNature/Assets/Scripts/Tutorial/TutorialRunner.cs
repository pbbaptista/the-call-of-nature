using UnityEngine;
using UnityEngine.UIElements;

public class TutorialRunner : MonoBehaviour
{
    [SerializeField] private TutorialStep_Dodge stepDodge;
    [SerializeField] private TutorialStep_Move stepMove;
    [SerializeField] private TutorialStep_Poop stepPoop;
    [SerializeField] private TutorialStep_ScarePeople stepScare;
    [SerializeField] private UIDocument uiTutorialDocument;
    [SerializeField] private GameObject player;


    public GameObject tutorialBg;

    private ITutorialStep _current;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialBg.SetActive(true);

        Begin(stepScare, "scare", unlockMovement: true);

        // Begin(stepPoop, "scare", unlockMovement: true);

        //stepPoop.OnCompleted += () => Begin(stepScare, "scare", unlockMovement: true);
        //stepScare.OnCompleted += () => Begin(stepMove, "move", unlockMovement: false);
        //stepMove.OnCompleted += () => Begin(stepDodge, "dodge", unlockMovement: false);

        // TODO: to go back to original order once all steps of the tutorial are implemented
        stepScare.OnCompleted += () => Begin(stepMove, "move", unlockMovement: false);
    }

    private void Begin(ITutorialStep next, string directiveName, bool unlockMovement)
    {
        _current?.Exit();
        _current = next;

        var rb = player.GetComponent<Rigidbody2D>();
        if (unlockMovement) {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        _current.Enter(uiTutorialDocument, directiveName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
