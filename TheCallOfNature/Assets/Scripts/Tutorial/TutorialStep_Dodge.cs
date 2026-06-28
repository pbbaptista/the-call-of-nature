using UnityEngine.UIElements;

internal class TutorialStep_Dodge : AbstractTutorialStep, ITutorialStep
{
    void ITutorialStep.Enter(UIDocument uiTutorialDocument, string directiveName)
    {
        Enter(uiTutorialDocument, directiveName);
    }

    void ITutorialStep.Exit()
    {
        Exit();
    }
}
