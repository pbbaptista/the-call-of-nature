using System;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

internal class TutorialStep_ScarePeople : AbstractTutorialStep, ITutorialStep
{
    [SerializeField] private float audioThreshold = 0.1f;
    [SerializeField] private float loudnessSensibility = 100;
    [SerializeField] private AudioLoudnessDetection detector;

    private AudioSource _audioSource;
    void ITutorialStep.Enter(UIDocument uiTutorialDocument, string directiveName)
    {
        Enter(uiTutorialDocument, directiveName);
        AudioSource audioSource = GetComponent<AudioSource>();
        _audioSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
    }

    void ITutorialStep.Exit()
    {
        Exit();
    }

    public void Update()
    {
        if (_audioSource != null)
        {
            float loudness = 
                detector
                .GetLoudnessFromAudioClip(_audioSource.timeSamples, _audioSource.clip)
                * loudnessSensibility;
            if (loudness > audioThreshold) {
                // scare people away
                Debug.Log("Sound from mic is loud enough to scare people away");
            }
        }
    }
}
