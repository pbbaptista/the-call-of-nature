using System;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

internal class TutorialStep_ScarePeople : AbstractTutorialStep, ITutorialStep
{
    [SerializeField] private float audioThreshold = 0.1f;
    [SerializeField] private float loudnessSensibility = 100;
    [SerializeField] private AudioLoudnessDetection detector;
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
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        if (loudness > audioThreshold)
        {
            // scare people away
            Debug.Log("Sound from mic is loud enough to scare people away");
        }
    }
}
