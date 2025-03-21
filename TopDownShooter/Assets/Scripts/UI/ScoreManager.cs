using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;  // Reference to the TextMeshPro object where the score will be displayed
    private int score = 0;  // Current score
    public int Score
    {
        get { return this.score; }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadScore();  // Load the saved score when the game starts
        UpdateScore();
    }

    private  void UpdateScore()
    {
        scoreText.text = "Points: " + score;
    }

    public void AddScore(int points)
    {
        score += points;        // Increase the score by the specified points
        UpdateScore();      // Update the UI text to reflect the new score
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("RecentScore", score);  // Save the score to PlayerPrefs
        PlayerPrefs.Save();  // Make sure the data is saved immediately
    }

    // Method to load the score from PlayerPrefs
    private void LoadScore()
    {
        score = PlayerPrefs.GetInt("RecentScore", 0);  // Load the saved score (defaults to 0 if not found)
    }

}
