internal interface ITutorialStep
{
    public void Enter()
    {
        // show prompt, start tracking input
    }

    public void Exit()
    {
        // stop tracking / unsubscribe
    }

    // Call this when the condition is met:
    private void Complete()
    {
    }
}