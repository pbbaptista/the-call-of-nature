/*
 * Adapted from Valem Tutorials video " How to Use Your Voice as Input in Unity - Microphone and Audio Loudness Detection "
 * Link to video tutorial: https://www.youtube.com/watch?v=dzD0qP8viLw
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{

    public int sampleWindow = 64;

    private AudioClip microphoneClip;
    private string microphoneName;

    void Start()
    {
        MicrophoneToAudioClip();
    }


    void Update()
    {
        
    }

    public void MicrophoneToAudioClip()
    {
        microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);

    }
    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(microphoneName), microphoneClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData,startPosition);

        // compute loudness
        float totalLoudness = 0;

        for(int i=0; i < sampleWindow; i++){
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;

    }

}
