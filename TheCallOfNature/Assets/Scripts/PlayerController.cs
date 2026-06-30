using UnityEngine;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{

    public GameObject player;

    [SerializeField] private float audioThreshold = 0.1f;
    [SerializeField] private float loudnessSensibility = 100;
    [SerializeField] private AudioLoudnessDetection detector;

    [SerializeField] private GameObject soundwave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone)
            || Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
            if (loudness > audioThreshold)
            {
                soundwave.SetActive(true);
                // scare people away
                Debug.Log($"Triggering soundwave that scares people away. \r\n" +
                    $" {nameof(loudness)}: {loudness}, \r\n " +
                    $"{nameof(loudnessSensibility)} : {loudnessSensibility}, \r\n" +
                    $" {nameof(audioThreshold)}: {audioThreshold}.");
            }
            else
            {
                soundwave.SetActive(false);
            }
        }
    }
}
