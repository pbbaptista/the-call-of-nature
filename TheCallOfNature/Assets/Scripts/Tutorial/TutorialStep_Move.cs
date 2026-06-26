using Assets.Scripts;
using UnityEngine;

internal class TutorialStep_Move : AbstractTutorialStep, ITutorialStep
{

    public GyroLateralMovement movement;
    public float threshold = 0.5f; // how far off-center counts as "moved"

    private bool movedLeft, movedRight, movedUp, movedDown;

    public bool TutorialMovementComplete =>
        movedLeft && movedRight && movedUp && movedDown;

    void Update()
    {
        float h = movement.NormalizedHorizontal;
        float v = movement.NormalizedVertical;

        if (h < -threshold) movedLeft = true;
        if (h > threshold) movedRight = true;
        if (v > threshold) movedUp = true;
        if (v < -threshold) movedDown = true;

        if (TutorialMovementComplete)
        {
            this.OnCompleted.Invoke();
        }
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
