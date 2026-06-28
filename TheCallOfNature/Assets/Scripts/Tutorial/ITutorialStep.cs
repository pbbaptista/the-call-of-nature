using UnityEngine;
using UnityEngine.UIElements;

internal interface ITutorialStep
{
    void Enter(UIDocument uiTutorialDocument, string directiveName);

    void Exit();
}