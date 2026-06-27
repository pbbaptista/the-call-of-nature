using UnityEngine;

internal class TutorialStep_Move : AbstractTutorialStep, ITutorialStep
{

    public float threshold = 0.5f; // how far off-center counts as "moved"

    private bool movedLeft, movedRight, movedUp, movedDown;

    public bool TutorialMovementComplete =>
        movedLeft && movedRight && movedUp && movedDown;

    void Update()
    {
    }


    public void Enter()
    {
        // show prompt, start tracking directions
    }

    public void Exit()
    {
        // stop tracking / unsubscribe
    }
}
