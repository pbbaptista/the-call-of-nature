using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class LogSharer : MonoBehaviour
{
    [SerializeField] private FileLogger fileLogger;
    [SerializeField] private UIDocument uiDocumentWithShareButton;

    private Button shareButton;

    void Start()
    {
        shareButton = uiDocumentWithShareButton.rootVisualElement.Q<Button>("shareButton");
        shareButton.clicked += ShareLogFile;
    }

    void ShareLogFile()
    {
        // Make sure the writer's buffer is flushed before sharing
        string path = fileLogger.GetLogFilePath();

        if (!System.IO.File.Exists(path))
        {
            Debug.LogWarning("Log file not found at: " + path);
            return;
        }

        fileLogger.Close();

        new NativeShare()
            .AddFile(path)
            .SetSubject("Playtest Log: " + DateTime.UtcNow)
            .SetText("Here's my session log from the playtest!")
            .SetCallback((result, shareTarget) =>
                Debug.Log("Share result: " + result + ", target: " + shareTarget))
            .Share();
    }

    void OnDisable()
    {
        shareButton.clicked -= ShareLogFile;
    }
}