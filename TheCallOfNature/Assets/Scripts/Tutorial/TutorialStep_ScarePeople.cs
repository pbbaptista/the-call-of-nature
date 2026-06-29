using System;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

internal class TutorialStep_ScarePeople : AbstractTutorialStep, ITutorialStep
{
    void ITutorialStep.Enter(UIDocument uiTutorialDocument, string directiveName)
    {
        Enter(uiTutorialDocument, directiveName);
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // The user has authorized use of the microphone.
        }
        else
        {
            // The user has not authorized microphone usage.
            // Ask for microphone permission.
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    void ITutorialStep.Exit()
    {
        Exit();
    }

    public void Update()
    {
        if (GameObject.FindWithTag("Person") == null)
            Complete();
    }
}
