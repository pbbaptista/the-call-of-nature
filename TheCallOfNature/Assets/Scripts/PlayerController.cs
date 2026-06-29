using UnityEngine;

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
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        if (loudness > audioThreshold)
        {
            soundwave.SetActive(true);
            // scare people away
            Debug.Log("Sound from mic is loud enough to scare people away");
        }
        else
        {
            soundwave.SetActive(false);
        }
    }
}
