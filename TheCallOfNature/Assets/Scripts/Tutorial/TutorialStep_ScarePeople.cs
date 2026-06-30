using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

internal class TutorialStep_ScarePeople : AbstractTutorialStep, ITutorialStep
{
    void ITutorialStep.Enter(UIDocument uiTutorialDocument, string directiveName)
    {
        Enter(uiTutorialDocument, directiveName);
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone) 
            || Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            // The user has authorized use of the microphone.
            Debug.Log($"User has given permission to use {nameof(Permission.Microphone)}");
        }
        else
        {
            Debug.Log($"Requesting user permission to use {nameof(Permission.Microphone)}");
            // The user has not authorized microphone usage.
            // Ask for microphone permission.
            Permission.RequestUserPermission(Permission.Microphone);
            Application.RequestUserAuthorization(UserAuthorization.Microphone);
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
