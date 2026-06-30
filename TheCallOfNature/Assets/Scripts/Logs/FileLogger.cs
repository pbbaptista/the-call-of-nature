using System;
using System.IO;
using UnityEngine;

public class FileLogger : MonoBehaviour
{
    private string logFilePath;
    private StreamWriter writer;

    void Awake()
    {
        string fileName = $"log_{DateTime.UtcNow:yyyyMMdd_HHmmss}.txt";
        logFilePath = Path.Combine(Application.persistentDataPath, fileName);
        writer = new StreamWriter(logFilePath, true);
        writer.AutoFlush = true;

        Application.logMessageReceived += HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        writer.WriteLine($"[{DateTime.UtcNow:HH:mm:ss.fff}] [{type}] {logString}");
        if (type == LogType.Exception || type == LogType.Error)
            writer.WriteLine(stackTrace);
    }

    public string GetLogFilePath() => logFilePath;

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
        writer?.Flush();
        writer?.Close();
    }
}