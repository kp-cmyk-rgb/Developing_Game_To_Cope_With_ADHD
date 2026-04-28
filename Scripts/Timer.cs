using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    bool isRunning = true;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        elapsedTime = 0;
        isRunning = true;
    }
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}