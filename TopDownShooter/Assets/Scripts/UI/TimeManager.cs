using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // If you want to use TextMeshPro for UI text


public class TimeManager : MonoBehaviour
{
    private float timer = 0f;  // The timer variable to store the elapsed time
    public TMP_Text timerText;  // Reference to the TMP text object to display the time

    void Update()
    {
        timer += Time.deltaTime;  // Increment timer by the time passed since the last frame
        DisplayTime(timer);  // Display the updated time
    }

    // Format and display the time in minutes:seconds format
    private void DisplayTime(float timeToDisplay)
    {
        // Convert the time to minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
