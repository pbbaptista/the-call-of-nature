using UnityEngine;

internal class TutorialStep_Move : AbstractTutorialStep, ITutorialStep
{
    // how far off from initial position counts as "moved"
    public float threshold = 1f;
    
    public GameObject player;

    private Vector3 startPosition;
    private bool movedLeft, movedRight, movedUp, movedDown;

    public bool TutorialMovementComplete =>
        movedLeft && movedRight && movedUp && movedDown;

    void Start()
    {
        startPosition = player.transform.position;
    }

    void Update()
    {
        var currentPosition = player.transform.position;

        // check if player has moved from initial position
        if (Mathf.Abs(startPosition.x - currentPosition.x) > threshold
            || Mathf.Abs(startPosition.y - currentPosition.y) > threshold)
        {
            if (!movedRight && currentPosition.x > startPosition.x + threshold)
                movedRight = true;
            else if (!movedLeft && currentPosition.x < startPosition.x - threshold)
                movedLeft = true;

            if (!movedUp && currentPosition.y > startPosition.y + threshold)
                movedUp = true;
            else if (!movedDown && currentPosition.y < startPosition.y - threshold)
                movedDown = true;

            if (TutorialMovementComplete)
            {
                this.Complete();
            }
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
